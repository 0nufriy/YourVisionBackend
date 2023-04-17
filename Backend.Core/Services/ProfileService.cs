using Backend.Core.Interfaces;
using Backend.Core.Metods;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class ProfileService : IProfileService
    {

       


        private ApplicationContext _context;
        public ProfileService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<LoginDTO> Login(ProfileLoginDTO loginDTO)
        {
            var a = await _context.Profile.FirstOrDefaultAsync(x => x.Login == loginDTO.login);
            if (a == null)
            {
                return null;
            }
            if (a.password == HashPassword.Hash(loginDTO.password))
            {
                return await _context.Profile
                    .Select(x => new LoginDTO { Email = x.Email, Login = x.Login, Name = x.Name, PhoneNumber = x.PhoneNumber, ProfileId = x.ProfileId, Role = x.Role })
                    .FirstOrDefaultAsync(x => x.Login == loginDTO.login);
            }
            return null;
        }
        public async Task<LoginDTO> Registration(ProfilePostDTO profilePostDTO)
        {
            Profile toAdd = new Profile();
            toAdd.PhoneNumber = profilePostDTO.PhoneNumber;
            toAdd.Name = profilePostDTO.Name;
            toAdd.Login = profilePostDTO.Login;
            toAdd.Role = profilePostDTO.Role;
            toAdd.password = HashPassword.Hash(profilePostDTO.password);
            toAdd.Email = profilePostDTO.Email;

            var add = await _context.Profile.AddAsync(toAdd);
            if (add.Entity == null)
            {
                return null;
            }
            try
            {

                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            var res = await Login(new ProfileLoginDTO { login = profilePostDTO.Login, password = profilePostDTO.password });
            if (res == null)
            {
                return null;
            }

            return res;
        }




        public async Task<ProfileGetDTO> GetProfile(int id)
        {
            ProfileGetDTO? res = await _context.Profile
                .Select(x => new ProfileGetDTO { Email = x.Email, Name = x.Name, Login = x.Login, PhoneNumber = x.PhoneNumber, ProfileId = x.ProfileId, Role = x.Role })
                .FirstOrDefaultAsync(x => x.ProfileId == id);
            return res;
        }

        public async Task<List<ProfileGetDTO>> GetProfiles()
        {
            List<ProfileGetDTO> res = await _context.Profile
                .Select(x => new ProfileGetDTO { Email = x.Email, Name = x.Name, Login = x.Login, PhoneNumber = x.PhoneNumber, ProfileId = x.ProfileId, Role = x.Role })
                .ToListAsync();
            return res;
        }

        

        public async Task<bool> ProfileDelete(int id)
        {
            Profile toDel = await _context.Profile.FirstOrDefaultAsync(x => x.ProfileId == id);
            if (toDel == null)
            {
                return false;
            }
            var res = _context.Profile.Remove(toDel);
            if (res.Entity == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProfileGetDTO> ProfilePatch(ProfilePatchDTO profilePatchDTO)
        {
            var toUpdate = await _context.Profile.FirstOrDefaultAsync(x => x.ProfileId == profilePatchDTO.ProfileId);
            if (toUpdate == null)
            {
                return null;
            }
            toUpdate.PhoneNumber = profilePatchDTO.PhoneNumber;
            toUpdate.Role = profilePatchDTO.Role;
            toUpdate.Email = profilePatchDTO.Email;
            toUpdate.Login = profilePatchDTO.Login;
            toUpdate.Name = profilePatchDTO.Name;

            await _context.SaveChangesAsync();

            ProfileGetDTO? res = await _context.Profile
                .Select(x => new ProfileGetDTO { Name = x.Name, Login = x.Login, Email = x.Email, PhoneNumber = x.PhoneNumber, ProfileId = x.ProfileId, Role = x.Role })
                .FirstOrDefaultAsync(x => x.ProfileId == profilePatchDTO.ProfileId);
            return res;
        }
       
        public async Task<ProfileGetDTO> ProfileChangePasswort(string login, string oldPassword, string newPassword)
        {
            var a = await _context.Profile.FirstOrDefaultAsync(x => x.Login == login);
            if (a == null)
            {
                return null;
            }
            if (a.password == HashPassword.Hash(oldPassword))
            {

                var toUp = await _context.Profile.FirstOrDefaultAsync(y => y.Login == login);
                if(toUp == null) 
                {
                    return null;
                }
                toUp.password = HashPassword.Hash(newPassword);

                await _context.SaveChangesAsync();

                return await _context.Profile
                    .Select(x => new ProfileGetDTO { Email = x.Email, Login = x.Login, Name = x.Name, PhoneNumber = x.PhoneNumber, ProfileId = x.ProfileId, Role = x.Role })
                    .FirstOrDefaultAsync(x => x.Login == login);
            }
            return null;
        }
    }
}
