using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Application.Models.Response;
using System.Security.Claims;

namespace RB.TBC.FinalProjectAPI.Controllers
{
    
     /// <summary>
    /// Class for Manage Feadback Related Operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FeadBackController : ControllerBase
    {
        private readonly IFeadbackService ser;

        /// Initializes a new instance of the <see cref="FeadBackController"/> class.
        /// <param name="ser">The feadback service.</param>
        public FeadBackController(IFeadbackService ser)
        {
            this.ser = ser;
        }
        /// <summary>
        ///Add New Feadbacks  to db 
        /// </summary>
        /// <returns>A response containing long </returns>
        [HttpPost]
        public async Task<ActionResult<string>> AddAsync([FromBody] FeadbackModel entity)
        {
            var userid=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Name = User.FindFirst(ClaimTypes.Name)?.Value;
            var Email = User.FindFirst(ClaimTypes.Email)?.Value;
            var res = await ser.AddAsync(entity, userid ?? throw new UnauthorizedAccessException("Access Denied"),Name??throw new UnauthorizedAccessException("Denied"),Email??throw new UnauthorizedAccessException(" Bad mail"));
            return Ok(res);
        }


        /// <summary>
        /// Retrive All Feadbacks
        /// </summary>
        /// <returns>A response containing aList of Feadbacks </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeadbackModelResponse>>> GetAllAsync()
        {

            var res = await ser.GetAllAsync();
            return Ok(res);
        }

        /// <summary>
        /// Retrive Feadback by id 
        /// </summary>
        /// <returns>A response containing a feadback </returns>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("{id:alpha}")]
        public async Task<ActionResult<FeadbackModelResponse>> GetByIdAsync([FromRoute]string id)
        {
            var res = await ser.GetByIdAsync(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest(id);
        }

        /// <summary>
        ///Remove  Feadback from Database
        /// </summary>
        /// <returns>A response containing boolean </returns>
        [HttpDelete]
        [Route("{id:alpha}")]
        [Authorize(Roles = "Admin,Manager,Operator")]
        public async Task<ActionResult<bool>> RemoveAsync([FromRoute]string id)
        {
            var res = await ser.RemoveAsync(id);
            if (res == false)
            {
                return BadRequest(id);
            }
            return Ok(res);
        }

        /// <summary>
        ///Soft Delete  Feadback from Database 
        /// </summary>
        /// <returns>A response containing boolean </returns>
        [HttpPost]
        [Route("{id:alpha}")]
        [Authorize(Roles = "Admin,Manager,Operator")]
        public async Task<ActionResult<bool>> SoftDeleteAsync([FromRoute]string id)
        {
            var res = await ser.SoftDeleteAsync(id);
            if (res == false)
            {
                return BadRequest(id);
            }
            return Ok(id);
        }
    }
}
