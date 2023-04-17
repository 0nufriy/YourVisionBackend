using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend.Core.Services
{
    public class SessionService : ISessionService
    {
        private ApplicationContext _context;

        public SessionService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ReportAllData> ReportAllData(int sessionId)
        {
           

            var sessionInfo = SessionGetById(sessionId).Result;
            if (sessionInfo == null)
            {
                return null;
            }
            ReportAllData res = new ReportAllData();

            res.SessionId = sessionId;
            res.Datetime = sessionInfo.Datetime;
            res.Status = sessionInfo.Status;
            res.DurationMinute = sessionInfo.DurationMinute;
            res.ProfileId = sessionInfo.ProfileId;
            res.Location = sessionInfo.Location;

            if (res.ProfileId != null)
            {
                var profileInfo = await _context.Profile.FirstOrDefaultAsync(x => x.ProfileId == res.ProfileId);
                res.Name = profileInfo.Name;
                res.Login = profileInfo.Login;
                res.PhoneNumber = profileInfo.PhoneNumber;
                res.Email = profileInfo.Email;
            }

            EmotionService es = new EmotionService(_context);
            res.EmotionalGet = await es.GetEmotionals(sessionId);

            res.AudiencePacks = _context.AAP
                .Include(x => x.Audience)
                .Include(x => x.AudiencePack)
                .ThenInclude(x => x.AudienceSession)
                .Where(x => x.AudiencePack.AudienceSession.Any(y => y.AudiencePackId == x.AudiencePackId && y.SessionId == sessionId))
                .Select(x => new { AudiencePack = x.AudiencePack, AudiencePackId = x.AudiencePackId, Audience = x.Audience, AudienceId = x.AudienceId, AudienceCount = x.AudienceCount, Count = x.AudiencePack.AudienceSession.FirstOrDefault(y => y.AudiencePackId == x.AudiencePackId && y.SessionId == sessionId).AudiencePackCount })
                .ToList()
                .GroupBy(x => new { Age = x.Audience.Age, AudienceId = x.AudienceId, Sex = x.Audience.Sex })
                .Select(x => new AudienceForReportDTO
                {
                    Age = x.Key.Age,
                    AudienceId = x.Key.AudienceId,
                    Sex = x.Key.Sex,
                    AudienceCount = x.Sum(s => s.AudienceCount * s.Count)
                }).ToList();

            return res;

        }

        public async Task<ReportGetDTO> ReportGet(int sessionId)
        {
            ReportGetDTO? reportGetDTO = await _context.Report.Include(x => x.Session)
                .Select(x => new ReportGetDTO { SessionId = x.SessionId, ReportId = x.ReportId, ReportPath = x.ReportPath, UserId = x.Session.ProfileId})
                .FirstOrDefaultAsync(x => x.SessionId == sessionId);
            return reportGetDTO;
        }

        public async Task<ReportGetDTO> ReportPost(int sessionId)
        {
            Report toAdd = new Report();
            toAdd.SessionId = sessionId;
            toAdd.ReportPath = $"report/{sessionId}.xlsx";
            await _context.Report.AddAsync(toAdd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
           
            ReportGetDTO res = await ReportGet(sessionId);

            return res;

        }

        public async Task<bool> SessionDelete(int id)
        {
            Session? session = await _context.Session.FirstOrDefaultAsync(x => x.SessionId == id);
            if(session == null)
            {
                return false;
            }
            var res = _context.Session.Remove(session);
            if(res == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SessionGetDTO>> SessionGet()
        {
            var sessions = await _context.Session
                .Include(x => x.AudienceSession)
                .ToListAsync();
            List<SessionGetDTO> res = new List<SessionGetDTO>();
            foreach (var session in sessions)
            {
                res.Add(new SessionGetDTO()
                {
                    Datetime = session.Datetime,
                    SessionId = session.SessionId,
                    ProfileId = session.ProfileId,
                    Status = session.Status,
                    DurationMinute = session.DurationMinute,
                    Location = session.Location,
                    AudiencePacks = _context.AudienceSession
                    .Where(x => x.SessionId == session.SessionId)
                    .Select(x => new AudienceSessionDTO { AudiencePackCount = x.AudiencePackCount, AudiencePackId =x.AudiencePackId })
                    .ToList(),
                });
            }
            return res;
        }

        public async Task<SessionGetDTO> SessionGetById(int id)
        {
            SessionGetDTO? res = await _context.Session
                .Select(x => new SessionGetDTO { Datetime = x.Datetime, DurationMinute = x.DurationMinute, ProfileId = x.ProfileId, SessionId = x.SessionId, Status = x.Status, Location = x.Location })
                .FirstOrDefaultAsync(x => x.SessionId == id);

            if(res == null)
            {
                return null;
            }

            res.AudiencePacks = await _context.AudienceSession
                .Where(x => x.SessionId == id)
                .Select(x => new AudienceSessionDTO { AudiencePackCount = x.AudiencePackCount, AudiencePackId = x.AudiencePackId })
                .ToListAsync();
            return res;
        }

        public async Task<List<SessionGetDTO>> SessionGetByProfile(int id)
        {
            var sessions = await _context.Session
                .Include(x => x.AudienceSession)
                .Where(x => x.ProfileId == id)
                .ToListAsync();
            List<SessionGetDTO> res = new List<SessionGetDTO>();
            foreach (var session in sessions)
            {
                res.Add(new SessionGetDTO()
                {
                    Datetime = session.Datetime,
                    SessionId = session.SessionId,
                    ProfileId = session.ProfileId,
                    Status = session.Status,
                    DurationMinute = session.DurationMinute,
                    Location = session.Location,
                    AudiencePacks = _context.AudienceSession.Include(x => x.Session)
                    .Where(x=> x.Session.ProfileId == id && x.SessionId == session.SessionId)
                    .Select(x => new AudienceSessionDTO { AudiencePackCount = x.AudiencePackCount, AudiencePackId = x.AudiencePackId })
                    .ToList(),
                });
            }
            return res;
        }

        public async Task<SessionGetDTO> SessionPatch(SessionPatchDTO sessionPatchDTO)
        {
            var ap = await _context.Session.FirstOrDefaultAsync(x => x.SessionId == sessionPatchDTO.SessionId);
            if (ap == null)
            {
                return null;
            }
            var aap = _context.AudienceSession.Where(x => x.SessionId == sessionPatchDTO.SessionId);
            if (aap != null)
            {
                _context.RemoveRange(aap);
            }
            ap.DurationMinute = sessionPatchDTO.DurationMinute;
            ap.Status = sessionPatchDTO.Status;
            ap.ProfileId = sessionPatchDTO.ProfileId;
            ap.Datetime = sessionPatchDTO.Datetime;
            ap.Location = sessionPatchDTO.Location;
            ap.AudienceSession = sessionPatchDTO.Audiences
                .Select(x => new AudienceSession { AudiencePackCount = x.AudiencePackCount, AudiencePackId = x.AudiencePackId})
                .ToList();

            await _context.SaveChangesAsync();
            var res = await SessionGetById(ap.SessionId);
            return res;
        }

        public async Task<SessionGetDTO> SessionPost(SessionPostDTO sessionPostDTO)
        {
            Session toAdd = new Session();
            toAdd.ProfileId = sessionPostDTO.ProfileId;
            toAdd.Datetime = sessionPostDTO.Datetime;
            toAdd.Status = sessionPostDTO.Status;
            toAdd.DurationMinute = sessionPostDTO.DurationMinute;
            toAdd.Location = sessionPostDTO.Location;
            toAdd.AudienceSession = sessionPostDTO.Audiences.Select(x => new AudienceSession { AudiencePackCount= x.AudiencePackCount, AudiencePackId= x.AudiencePackId}).ToList();
            var add = await _context.Session.AddAsync(toAdd);
            if(add == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            var res = await SessionGetById(add.Entity.SessionId);
            return res;
        }
    }
}
