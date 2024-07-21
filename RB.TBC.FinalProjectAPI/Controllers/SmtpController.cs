using Microsoft.AspNetCore.Mvc;

namespace RB.TBC.FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmtpController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok("Hello");
        }

        [HttpGet]
        [Route("/{id:int}")]
        public IActionResult GetDetailById(int id)
        {
            return Ok(id);
        }
    }
}
