using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Core.Metods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Metods;
using Backend.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService service;
        public ProfileController(IProfileService profileService)
        {
            service = profileService;
        }



        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<ProfileGetDTO>>> Get()
        {
            List<ProfileGetDTO> res = await service.GetProfiles();
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<ProfileGetDTO>> Get(int id)
        {
            var user = CurrentUser.Get(HttpContext);
            if (user.Role != "admin" && user.ProfileId != id)
            {
                return NotFound();
            }
            ProfileGetDTO res = await service.GetProfile(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ProfileGetDTO>> GetUser()
        {
            var user = CurrentUser.Get(HttpContext);
            ProfileGetDTO res = await service.GetProfile(user.ProfileId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var user = CurrentUser.Get(HttpContext);
            if (user.Role != "admin" && user.ProfileId != id)
            {
                return NotFound();
            }
            bool res = await service.ProfileDelete(id);
            if(res == false)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [Route("patch/{id}")]
        public async Task<ActionResult<ProfileGetDTO>> Patch(ProfilePatch profilePatchDTO, int id)
        {
            
            ProfileGetDTO res = await service.ProfilePatch(new ProfilePatchDTO() 
            { 
                Email = profilePatchDTO.Email, 
                Login = profilePatchDTO.Login, 
                Name = profilePatchDTO.Name, 
                PhoneNumber = profilePatchDTO.PhoneNumber,
                ProfileId = id,
                Role = profilePatchDTO.Role,
            });
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "user")]
        [HttpPatch]
        [Route("patch")]
        public async Task<ActionResult<ProfileGetDTO>> PatchUser(ProfilePatch profilePatchDTO)
        {

            var user = CurrentUser.Get(HttpContext);
            ProfileGetDTO res = await service.ProfilePatch(new ProfilePatchDTO()
            {
                Email = profilePatchDTO.Email,
                Login = profilePatchDTO.Login,
                Name = profilePatchDTO.Name,
                PhoneNumber = profilePatchDTO.PhoneNumber,
                ProfileId = user.ProfileId,
                Role = profilePatchDTO.Role,
            });
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [Authorize(Roles = "user")]
        [HttpPatch]
        [Route("patch/password")]
        public async Task<ActionResult<ProfileGetDTO>> PatchPassword( string oldPassword, string newPassword)
        {
            var user = CurrentUser.Get(HttpContext);
            
            ProfileGetDTO res = await service.ProfileChangePasswort(user.Login, oldPassword, newPassword);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
