using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Metods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmotionalController : ControllerBase
    {

        private readonly IEmotionService service;
        public EmotionalController(IEmotionService emotionalService)
        {
            service = emotionalService;
        }

        [Authorize]
        [HttpGet]
        [Route("getEmotional/{id}")]
        public async Task<ActionResult<EmotionalGetDTO>> EmotionalGet(int id)
        {
           
            EmotionalGetDTO res = await service.GetEmotionals(id);
            var user = CurrentUser.Get(HttpContext);
            if (user.Role != "admin" && user.ProfileId != res.ProfileId)
            {
                return NotFound();
            }
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("Result/post")]
        public async Task<ActionResult<EmotionalRDGetDTO>> ResultPost(EmotionalResultPostDTO postDTO)
        {
            EmotionalRDGetDTO res = await service.PostEmotionalResult(postDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("Expect/post")]
        public async Task<ActionResult<EmotionalEDGetDTO>> ExpectPost(EmotionalExpectPostDTO postDTO)
        {
            EmotionalEDGetDTO res = await service.PostEmotionalExpect(postDTO);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
