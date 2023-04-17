using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IAudienceService
    {
        Task<AudiencePackGetDTO> PostAudiencePack(AudiencePackPostDTO postDTO);
        Task<bool> DeleteAudiencePack(int id);
        Task<AudiencePackGetDTO> PatchAudiencePack(AudiencePackPatchDTO patchDTO);
        Task<AudiencePackGetDTO> GetAudiencePack(int id);
        Task<List<AudiencePackGetDTO>> GetAudiencePack();
        
        Task<List<AudienceGetDTO>> GetAudience();
        Task<List<AudienceGetDTO>> GetAudience(int[] id);

    }
}
