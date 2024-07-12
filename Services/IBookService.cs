using bookproject.DTOs;
using bookproject.Models;

namespace bookproject.Services
{
    public interface IBookService : IGenericRepository<Book>
    {
        public Task<responseDto> getAllAsync();
        public Task<responseDto> getByIdAsync(int Id);
        public Task<responseDto> updateByIdAsync(int Id, bookDto bookDto);
        public Task<responseDto> addAsync(bookDto bookDto);
        public Task<responseDto> deleteAsync(int Id);
    }
}
