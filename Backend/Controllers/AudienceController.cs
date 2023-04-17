using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    
    [Route("api/AudiencePack")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IAudienceService service;

        public AudienceController(IAudienceService audienceService) {
            service = audienceService;
        }


        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool res = await service.DeleteAudiencePack(id);

            return Ok(res);
        }


        [Authorize]
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<AudiencePackGetDTO>>> Get()
        {
            List<AudiencePackGetDTO> res = await service.GetAudiencePack();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<AudiencePackGetDTO>> Get(int id)
        {
            var res = await service.GetAudiencePack(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<AudiencePackGetDTO>> Post(AudiencePackPostDTO audiencePackPost)
        {
            AudiencePackGetDTO? res = await service.PostAudiencePack(audiencePackPost);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch]
        [Route("update")]
        public async Task<ActionResult<AudiencePackGetDTO>> Patch(AudiencePackPatchDTO audiencePackPatch)
        {
            var res = await service.PatchAudiencePack(audiencePackPatch);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("Audience/get")]
        public async Task<ActionResult<List<AudienceGetDTO>>> GetAudience()
        {
            List<AudienceGetDTO> res = await service.GetAudience();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("Audience/get/ids")]
        public async Task<ActionResult<List<AudienceGetDTO>>> GetAudience([FromQuery(Name = "id")] int[] ids)
        {
            List<AudienceGetDTO> res = await service.GetAudience(ids);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("Audience/post")]
        public async Task<ActionResult<List<AudienceGetDTO>>> PostAudience(AudiencePostDTO audiencePostDTO)
        {
            AudienceGetDTO res = await service.PostAudience(audiencePostDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [Route("Audience/udpate")]
        public async Task<ActionResult<List<AudienceGetDTO>>> PatchAudience(AudienceGetDTO audiencePostDTO)
        {
            AudienceGetDTO res = await service.PatchAudience(audiencePostDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("Audience/delete/{id}")]
        public async Task<ActionResult<List<AudienceGetDTO>>> PostAudience(int id)
        {
            bool res = await service.DeleteAudience(id);
            return Ok(res);
        }

    }
}
