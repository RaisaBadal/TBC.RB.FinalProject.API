using Microsoft.AspNetCore.Mvc;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;

namespace RB.TBC.FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService ser;

        public ContactUsController(IContactUsService ser)
        {
            this.ser = ser;
        }

        [HttpPost]
        [Route("SendMessageToAdmin")]
        public IActionResult SendMesaggeToAdmin([FromBody]ContactUsModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new ArgumentException("Some arguments not correct");
                }
                var res = ser.SendMesaggeToAdmin(model);
                if (res) return Ok(res);
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
