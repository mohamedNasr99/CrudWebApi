using bookproject.DTOs;
using bookproject.Models;

namespace bookproject.Services
{
    public interface ICategoryService : IGenericRepository<Category>
    {
        public Task<responseDto> getAllAsync();
        public Task<responseDto> getByIdAsync(int Id);
        public Task<responseDto> updateByIdAsync(int Id, categoryDto categoryDto);
        public Task<responseDto> addAsync(categoryDto categoryDto);
        public Task<responseDto> deleteAsync(int Id);
    }
}
