using bookproject.DTOs;
using bookproject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllAsync()
        {
            var books = await _unitOfWork.Books.getAllAsync();

            if (books.statusCode == 200)
            {
                return Ok(books);
            }

            return NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> getByIdAsync(int Id)
        {
            var book = await _unitOfWork.Books.getByIdAsync(Id);

            if (book.statusCode == 200)
            {
                return Ok(book);
            }

            return BadRequest(book);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteAsync(int Id)
        {
            var book = await _unitOfWork.Books.deleteAsync(Id);

            if (book.statusCode == 200)
            {
                return Ok(book);
            }

            return BadRequest(book.message);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> addAsync([FromQuery]bookDto bookDto)
        {
            var book = await _unitOfWork.Books.addAsync(bookDto);

            if (book.statusCode == 200)
            {
                return Ok(book);
            }

            return BadRequest(book.message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> updateAsync(int Id, bookDto bookDto)
        {
            var book = await _unitOfWork.Books.updateByIdAsync(Id, bookDto);

            if (book.statusCode == 200)
            {
                return Ok(book);
            }

            return BadRequest(book.message);
        }
    }
}
