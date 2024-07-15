using AutoMapper;
using bookproject.Data;
using bookproject.DTOs;
using bookproject.Models;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Services
{
    public class AuthorService : GenericRepository<Author>, IAuthorService
    {
        private new readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this._context =context;
            this._mapper = mapper;
        }

        public async Task<responseDto> addAsync(string Name)
        {
            Author author = new Author { Name = Name };

            await _context.Authors.AddAsync(author);
            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "added successfully",
                    model = Name
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "failed to add Author",
                model = null
            };
            
        }

        public async Task<responseDto> deleteAsync(int Id)
        {
            var author = await _context.Authors.FindAsync(Id);

            if (author != null)
            {
                _context.Authors.Remove(author);

                await _context.SaveChangesAsync();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Remove Author is successeded",
                    model = author
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Remove Author is failed, as no Author with this Id",
                model = null
            };
        }

        public async Task<responseDto> getAllAsync()
        {
            var authors = await _context.Authors.Include(a => a.Books).ToListAsync();

            var destination = _mapper.Map<List<authorDto>>(authors);

            if (authors != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "There are Authors",
                    model = destination
                };
            }

            return new responseDto
            {
                statusCode = 204,
                isSuccess = false,
                message = "There are no Authors",
                model = null
            };
        }

        public async Task<responseDto> getByIdAsync(int Id)
        {
            var author = await _context.Authors
                                    .Include(a => a.Books)
                                    .FirstOrDefaultAsync(a => a.Id == Id);

            var destination = _mapper.Map<authorDto>(author);


            if (author != null)
            {
                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Successfully",
                    model = destination
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Not Successfully",
                model = null
            };
        }

        public async Task<responseDto> updateByIdAsync(int Id, authorDto authorDto)
        {
            var author = await _context.Authors.FindAsync(Id);

            if (author != null)
            {
                author.Name = authorDto.Name;

                _context.Authors.Update(author);

                _context.SaveChanges();

                return new responseDto
                {
                    statusCode = 200,
                    isSuccess = true,
                    message = "Update is successeded",
                    model = authorDto
                };
            }

            return new responseDto
            {
                statusCode = 400,
                isSuccess = false,
                message = "Update is failed",
                model = null
            };
        }
    }
}
