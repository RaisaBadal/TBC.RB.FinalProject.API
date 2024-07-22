using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using System.Security.Claims;

namespace RB.TBC.FinalProject.API.Controllers
{
    /// <summary>
    /// Controller for managing favorites.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly ILogger<FavoriteController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoriteController"/> class.
        /// </summary>
        /// <param name="favoriteService">The favorite service.</param>
        /// <param name="logger">The logger.</param>
        public FavoriteController(IFavoriteService favoriteService, ILogger<FavoriteController> logger)
        {
            _favoriteService = favoriteService;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new favorite.
        /// </summary>
        /// <param name="model">The favorite model.</param>
        /// <returns>The created favorite ID.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> AddAsync([FromBody] FavoriteModel model)
        {
            if (model == null)
            {
                return BadRequest("Favorite model is null");
            }

            var Userid=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _favoriteService.AddAsync(model,Userid??throw new UnauthorizedAccessException("Not authorized"));
            return CreatedAtAction(nameof(GetByIdAsync), new { userId =Userid, bookId = model.BookId }, result);
        }

        /// <summary>
        /// Gets all favorites.
        /// </summary>
        /// <returns>A list of favorites.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteModel>>> GetAllAsync()
        {
            var result = await _favoriteService.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Gets a favorite by user ID and book ID.
        /// </summary>
        /// <param name="bookId">The book ID.</param>
        /// <returns>The favorite.</returns>
        [HttpGet("{bookId:alpha}")]
        public async Task<ActionResult<FavoriteModel>> GetByIdAsync([FromRoute]string bookId)
        {
            var Userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _favoriteService.GetByIdAsync(Userid??throw new UnauthorizedAccessException("Not authorized"), bookId);
            if (result == null)
            {
                return NotFound("Favorite not found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Removes a favorite by user ID and book ID.
        /// </summary>
        /// <param name="bookId">The book ID.</param>
        /// <returns>No content if the favorite was removed.</returns>
        [HttpDelete("{bookId:alpha}")]
        public async Task<ActionResult> RemoveAsync([FromRoute]string bookId)
        {
            var Userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _favoriteService.RemoveAsync(Userid ?? throw new UnauthorizedAccessException("Not authorized"), bookId);
            if (!result)
            {
                return NotFound("Favorite not found");
            }
            return NoContent();
        }
    }
}
