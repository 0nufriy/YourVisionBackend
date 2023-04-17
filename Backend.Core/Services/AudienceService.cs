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
    public class AudienceService : IAudienceService
    {
        private ApplicationContext _context;

        public AudienceService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAudiencePack(int id)
        {
            AudiencePack? audiencePack = await _context.AudiencePack.FirstOrDefaultAsync(ap => ap.AudiencePackId == id);
            if(audiencePack == null)
            {
                return false;
            }
            var res = _context.AudiencePack.Remove(audiencePack);

            if(res.Entity == null)
            {
                return false;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AudiencePackGetDTO> GetAudiencePack(int id)
        {
            var audiencePack = 
                await _context.AudiencePack
                .Include(ap => ap.AAPs)
                .FirstOrDefaultAsync(ap => ap.AudiencePackId == id);
            if (audiencePack == null)
            {
                return null;
            }


            AudiencePackGetDTO res = new AudiencePackGetDTO();
            res.AudiencePackId = audiencePack.AudiencePackId;
            res.AudiencePackName = audiencePack.AudiencePackName;
            res.Price = audiencePack.Price;
            res.Audiences = audiencePack.AAPs.Where(x => x.AudiencePackId == id).Select(x => new AAPDTO{ AudienceId = x.AudienceId, AudienceCount = x.AudienceCount }).ToList();
            return res;

        }

        public async Task<List<AudiencePackGetDTO>> GetAudiencePack()
        {
            var audiencePacks = await _context.AudiencePack.Include(ap=> ap.AAPs).ToListAsync();
            List<AudiencePackGetDTO> res = new List<AudiencePackGetDTO>();
            foreach(var audiencePack in audiencePacks)
            {
                res.Add(new AudiencePackGetDTO
                {
                    AudiencePackId = audiencePack.AudiencePackId,
                    AudiencePackName = audiencePack.AudiencePackName,
                    Price = audiencePack.Price,
                    Audiences = audiencePack.AAPs.Where(x => x.AudiencePackId == audiencePack.AudiencePackId).Select(x => new AAPDTO { AudienceId = x.AudienceId, AudienceCount = x.AudienceCount }).ToList()
                });
                
            }
            return res;
        }
        public async Task<AudiencePackGetDTO> PostAudiencePack(AudiencePackPostDTO postDTO)
        {
            AudiencePack toAdd = new AudiencePack
            {
                AudiencePackName = postDTO.AudiencePackName,
                Price = postDTO.Price,
                AAPs = postDTO.Audiences.Select(x => new AAP { AudienceCount = x.AudienceCount, AudienceId = x.AudienceId }).ToList()
            };
            var add = await _context.AudiencePack.AddAsync(toAdd) ;
            await _context.SaveChangesAsync();
            var res = await GetAudiencePack(add.Entity.AudiencePackId);
            return res;
        }

        public async Task<AudiencePackGetDTO> PatchAudiencePack(AudiencePackPatchDTO patchDTO)
        {
            var ap = await _context.AudiencePack.FirstOrDefaultAsync(x => x.AudiencePackId == patchDTO.AudiencePackId);
            if(ap == null)
            {
                return null;
            }
            var aap = _context.AAP.Where(x => x.AudiencePackId == patchDTO.AudiencePackId);
            if(aap != null)
            {
                _context.RemoveRange(aap);
            }
            ap.AudiencePackName = patchDTO.AudiencePackName;
            ap.Price = patchDTO.Price;
            ap.AAPs = patchDTO.Audiences.Select(x => new AAP { AudienceCount = x.AudienceCount, AudienceId = x.AudienceId, AudiencePackId = patchDTO.AudiencePackId }).ToList();

            await _context.SaveChangesAsync();
            var res = await GetAudiencePack(patchDTO.AudiencePackId);
            return res;
        }

        public async Task<List<AudienceGetDTO>> GetAudience()
        {
            var a =  _context.Audience.ToList();
            
            if(a == null)
            {
                return null;
            }
            List<AudienceGetDTO> res = new List<AudienceGetDTO>();
            foreach(var item in a)
            {
                res.Add(new AudienceGetDTO
                {
                    AudienceId = item.AudienceId,
                    Sex = item.Sex,
                    Age = item.Age
                });
            }
            return res;
        }

        public async Task<List<AudienceGetDTO>> GetAudience(int[] id)
        {
            List<AudienceGetDTO> res = await _context.Audience.Where(x => id.Contains(x.AudienceId)).Select(x => new AudienceGetDTO { AudienceId = x.AudienceId, Age = x.Age, Sex = x.Sex}).ToListAsync();
            
            return res;
        }
    }
}
