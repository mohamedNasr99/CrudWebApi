using bookproject.Data;
using bookproject.DTOs;
using bookproject.Models;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Services
{
    public class CategoryService : GenericRepository<Category>, ICategoryService
    {
        private new readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<responseDto> addAsync(categoryDto categoryDto)
        {
            Category category = new Category { Name = categoryDto.Name };

            await _context.Categories.AddAsync(category);
            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "added successfully",
                    model = categoryDto
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "failed to add Category",
                model = null
            };
        }

        public async Task<responseDto> deleteAsync(int Id)
        {
            var category = await _context.Categories.FindAsync(Id);

            if (category != null)
            {
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Deletion is seccesseded",
                    model = category
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Deletion is not seccesseded",
                model = null
            };
        }

        public async Task<responseDto> getAllAsync()
        {
            var categories = await _context.Categories.Include(c => c.Books).ToListAsync();

            if (categories != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "There are Categories",
                    model = categories
                };
            }

            return new responseDto
            {
                statusCode = 204,
                isSuccess = false,
                message = "There are no Categories",
                model = null
            };
        }

        public async Task<responseDto> getByIdAsync(int Id)
        {
            var category = await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == Id);

            if (category != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Successfully",
                    model = category
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "There is no Category with this Id",
                model = null
            };
        }

        public async Task<responseDto> updateByIdAsync(int Id, categoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(Id);

            if (category != null)
            {
                category.Name = categoryDto.Name;

                _context.Categories.Update(category);

                await _context.SaveChangesAsync();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Successfully",
                    model = category
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "There is no Category with this Id",
                model = null
            };
        }
    }
}
