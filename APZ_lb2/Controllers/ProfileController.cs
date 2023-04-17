using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APZ_lb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        [HttpGet("/profile")]
        public ActionResult test()
        {
           

            return Ok();
        }

    }
}
