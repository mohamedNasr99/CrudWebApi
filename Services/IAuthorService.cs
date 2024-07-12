using bookproject.DTOs;
using bookproject.Models;

namespace bookproject.Services
{
    public interface IAuthorService : IGenericRepository<Author>
    {
        public Task<responseDto> getAllAsync();
        public Task<responseDto> getByIdAsync(int Id);
        public Task<responseDto> updateByIdAsync(int Id, authorDto authorDto);
        public Task<responseDto> addAsync(string Name);
        public Task<responseDto> deleteAsync(int Id);
    }
}
