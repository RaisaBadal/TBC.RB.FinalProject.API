using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;

namespace RB.TBC.FinalProject.API.Controllers
{
    /// <summary>
    /// Controller for managing books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="bookService">The book service.</param>
        /// <param name="logger">The logger.</param>
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="model">The book model.</param>
        /// <returns>The created book ID.</returns>
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] BookModel model)
        {
                if (model == null||!ModelState.IsValid)
                {
                    return BadRequest("Book model is null");
                }

                var result = await _bookService.AddAsync(model);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = result }, result);
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>A list of books.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetAllAsync()
        {
            var result = await _bookService.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Gets a book by ID.
        /// </summary>
        /// <param name="id">The book ID.</param>
        /// <returns>The book.</returns>
        [HttpGet("{id:alpha}")]
        public async Task<ActionResult<BookModel>> GetByIdAsync([FromRoute] string id)
        {
                var result = await _bookService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound("Book not found");
                }
                return Ok(result);
        }

        /// <summary>
        /// Removes a book by ID.
        /// </summary>
        /// <param name="id">The book ID.</param>
        /// <returns>No content if the book was removed.</returns>
        [HttpDelete("{id:alpha}")]
        public async Task<ActionResult> RemoveAsync([FromRoute]string id)
        {
            var result = await _bookService.RemoveAsync(id);
            if (!result)
            {
                return NotFound("Book not found");
            }
            return NoContent();
        }

        /// <summary>
        /// Updates a book by ID.
        /// </summary>
        /// <param name="id">The book ID.</param>
        /// <param name="model">The updated book model.</param>
        /// <returns>No content if the book was updated.</returns>
        [HttpPut("{id:alpha}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]string id, [FromBody] BookModel model)
        {

            if (model == null)
            {
                return BadRequest("Book model is null");
            }

            var result = await _bookService.UpdateAsync(id, model);
            if (!result)
            {
                return NotFound("Book not found");
            }
            return NoContent();
        }
    }
}
