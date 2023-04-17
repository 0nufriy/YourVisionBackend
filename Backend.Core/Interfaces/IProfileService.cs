using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileGetDTO> Registration(ProfilePostDTO profilePostDTO);
        Task<ProfileGetDTO> Login(ProfileLoginDTO loginDTO);
        Task<ProfileGetDTO> ProfilePatch(ProfilePatchDTO profilePatchDTO);
        Task<ProfileGetDTO> ProfileChangePasswort(string login, string oldPassword, string newPassword);
        Task<bool> ProfileDelete(int id);
        Task<List<ProfileGetDTO>> GetProfiles();
        Task<ProfileGetDTO> GetProfile(int id);
    }
}
