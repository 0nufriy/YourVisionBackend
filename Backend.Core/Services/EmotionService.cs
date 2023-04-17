using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class EmotionService : IEmotionService
    {
        private ApplicationContext _context;

        public EmotionService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<EmotionalGetDTO> GetEmotionals(int sessionsId)
        {
            EmotionalGetDTO res = new EmotionalGetDTO();
            res.EmotionalExpect =  _context.EmotionalExpect
                .Include(x => x.Audience)
                .Where(x => x.SessionId == sessionsId)
                .GroupBy(x => new
                {
                    AudienceId = x.AudienceId,
                    Age = x.Audience.Age,
                    Sex = x.Audience.Sex
                })
                .Select(x => new EmotionalEGetDTO 
                {
                    AudienceId = x.Key.AudienceId,
                    Age = x.Key.Age,
                    Sex = x.Key.Sex,
                    EmotionalEDGetDTO = x.Select(x => new EmotionalEDGetDTO { AudienceId = x.AudienceId, Emotional = x.Emotional, EmotionalExpectId = x.EmotionalExpectId, End = x.End, Start = x.Start }).ToList() 
                }).ToList();
            res.EmotionalResult = _context.EmotionalResult
                .Where(x => x.SessionId == sessionsId)
                .Include(x => x.Audience)
                .GroupBy(x => new
                {
                    PersonId = x.PersonId,
                    AudienceId = x.AudienceId,
                    Age = x.Audience.Age,
                    Sex = x.Audience.Sex
                })
                .Select(x => new EmotionalRGetDTO
                {
                    PersonId = x.Key.PersonId,
                    AudienceId = x.Key.AudienceId,
                    Age = x.Key.Age,
                    Sex = x.Key.Sex,
                    RDGet = x.Select(x => new EmotionalRDGetDTO { AudienceId = x.AudienceId, Emotional = x.Emotional, EmotionalResultId = x.EmotionalResultId, End = x.End, Start = x.Start }).ToList()
                }).ToList();
            return res;
        }

        public async Task<EmotionalEDGetDTO> PostEmotionalExpect(EmotionalExpectPostDTO postDTO)
        {
            EmotionalExpect emotionalExpect = new EmotionalExpect();
            emotionalExpect.Start = postDTO.Start;
            emotionalExpect.End = postDTO.End;
            emotionalExpect.Emotional = postDTO.Emotional;
            emotionalExpect.SessionId = postDTO.SessionId;
            emotionalExpect.AudienceId = postDTO.AudienceId;
            var add = await _context.EmotionalExpect.AddAsync(emotionalExpect);

            await _context.SaveChangesAsync();

            var item = await _context.EmotionalExpect.FirstOrDefaultAsync(x => x.EmotionalExpectId == add.Entity.EmotionalExpectId);
            if (item == null)
                return null;

            

            EmotionalEDGetDTO res = new EmotionalEDGetDTO();
            res.Start = item.Start; 
            res.End = item.End;
            res.Emotional = item.Emotional;
            res.EmotionalExpectId = item.EmotionalExpectId;
            res.AudienceId = item.AudienceId;
            return res;
        }

        public async Task<EmotionalRDGetDTO> PostEmotionalResult(EmotionalResultPostDTO postDTO)
        {
            EmotionalResult emotionalResult = new EmotionalResult();
            emotionalResult.Start = postDTO.Start;
            emotionalResult.End = postDTO.End;
            emotionalResult.Emotional = postDTO.Emotional;
            emotionalResult.SessionId = postDTO.SessionId;
            emotionalResult.AudienceId = postDTO.AudienceId;
            emotionalResult.PersonId = postDTO.PersonId;
            var add = await _context.EmotionalResult.AddAsync(emotionalResult);

            await _context.SaveChangesAsync();

            var item = await _context.EmotionalResult.FirstOrDefaultAsync(x => x.EmotionalResultId == add.Entity.EmotionalResultId);
            if (item == null)
                return null;

           

            EmotionalRDGetDTO res = new EmotionalRDGetDTO();
            res.Start = item.Start;
            res.End = item.End;
            res.Emotional = item.Emotional;
            res.EmotionalResultId = item.EmotionalResultId;
            res.AudienceId = item.AudienceId;
            return res;
        }
    }
}
