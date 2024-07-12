using AutoMapper;
using bookproject.DTOs;
using bookproject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllAsync()
        {
            var categories = await _unitOfWork.Categories.getAllAsync();

            if (categories.statusCode == 200)
            {
                var destinationList = _mapper.Map<List<categoryDto>>(categories.model);
                return Ok(destinationList);
            }

            return NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> getByIdAsync(int Id)
        {
            var category = await _unitOfWork.Categories.getByIdAsync(Id);

            
            if (category.statusCode == 200)
            {
                var destination = _mapper.Map<categoryDto>(category.model);
                return Ok(destination);
            }

            return BadRequest(category);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteAsync(int Id)
        {
            var category = await _unitOfWork.Categories.deleteAsync(Id);

            if (category.statusCode == 200)
            {
                return Ok(category);
            }

            return BadRequest(category);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> addAsync([FromQuery]categoryDto categoryDto)
        {
            var category = await _unitOfWork.Categories.addAsync(categoryDto);

            if (category.statusCode == 200)
            {
                return Ok(category);
            }

            return BadRequest(category.message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> updateAsync(int Id, [FromQuery]categoryDto categoryDto)
        {
            var category = await _unitOfWork.Categories.updateByIdAsync(Id, categoryDto);

            if (category.statusCode == 200)
            {
                return Ok(category);
            }

            return BadRequest(category.message);
        }
    }
}
 