using AutoMapper;
using bookproject.DTOs;
using bookproject.Models;
using bookproject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookproject.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.getAllAsync();

            if (authors.isSuccess)
            {
                return Ok(authors);
            }

            return NoContent();
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var author = await _unitOfWork.Authors.getByIdAsync(Id);

            if (author.isSuccess)
            {
                return Ok(author);
            }

            return BadRequest(author);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromQuery]authorDto authorDto)
        {
            var author = await _unitOfWork.Authors.updateByIdAsync(Id, authorDto);

            if (author.isSuccess)
            {
                return Ok(author);
            }

            return BadRequest(author);
        }

        [HttpPost("{Name}")]
        public async Task<IActionResult> AddAsync(string Name)
        {
            var author = await _unitOfWork.Authors.addAsync(Name);

            if (author.isSuccess)
            {
                return Ok(author);
            }

            return BadRequest(author);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var author  = await _unitOfWork.Authors.deleteAsync(Id);

            if (author.isSuccess)
            {
                return Ok(author);
            }

            return BadRequest(author);
        }
    }
}
