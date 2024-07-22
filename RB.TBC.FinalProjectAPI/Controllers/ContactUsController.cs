using Microsoft.AspNetCore.Mvc;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;

namespace RB.TBC.FinalProjectAPI.Controllers
{
    /// <summary>
    /// Controller for handling Contact Us operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _ser;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsController"/> class.
        /// </summary>
        /// <param name="ser">The service to handle Contact Us operations.</param>
        public ContactUsController(IContactUsService ser)
        {
            _ser = ser;
        }

        /// <summary>
        /// Sends a message to the admin.
        /// </summary>
        /// <param name="model">The Contact Us model containing the message details.</param>
        /// <returns>Returns Ok if the message is sent successfully; otherwise, BadRequest or InternalServerError.</returns>
        [HttpPost]
        [Route("SendMessageToAdmin")]
        public IActionResult SendMessageToAdmin([FromBody] ContactUsModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Some arguments are not correct");
                }

                var result = _ser.SendMesaggeToAdmin(model);
                if (result)
                {
                    return Ok(result);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
