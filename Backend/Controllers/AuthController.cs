using Backend.Core.Interfaces;
using Backend.Core.Metods;
using Backend.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IProfileService service;
        private readonly IConfiguration _configuration;
        public AuthController(IProfileService profileService, IConfiguration configuration)
        {
            service = profileService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<LoginDTO>> Register(ProfilePostDTO profilePostDTO)
        {
            LoginDTO res = await service.Registration(profilePostDTO);
            if (res == null)
            {
                return NotFound();
            }

            res.Token = JWT.GenarateJWT(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], res);

            return Ok(res);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginDTO>> Login(ProfileLoginDTO loginDTO)
        {
            LoginDTO res = await service.Login(loginDTO);
            if (res == null)
            {
                return NotFound();
            }

            res.Token = JWT.GenarateJWT(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], res);
            return Ok(res);
        }
    }
}
