using Backend.Core.Interfaces;
using Backend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Route("get")]
        public async Task<ActionResult<List<ProfileGetDTO>>> Get()
        {
            List<ProfileGetDTO> res = await service.GetProfiles();
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<ProfileGetDTO>> Get(int id)
        {
            ProfileGetDTO res = await service.GetProfile(id);
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
            bool res = await service.ProfileDelete(id);
            if(res == false)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [Authorize]
        [HttpPatch]
        [Route("patch")]
        public async Task<ActionResult<ProfileGetDTO>> Patch(ProfilePatchDTO profilePatchDTO)
        {
            ProfileGetDTO res = await service.ProfilePatch(profilePatchDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpPatch]
        [Route("patch/password")]
        public async Task<ActionResult<ProfileGetDTO>> PatchPassword(string login, string oldPassword, string newPassword)
        {
            ProfileGetDTO res = await service.ProfileChangePasswort(login, oldPassword, newPassword);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
