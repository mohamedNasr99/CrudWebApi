using AutoMapper;
using bookproject.Data;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private IBookService _books;
        private ICategoryService _categories;
        private IAuthorService _authors;

        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public IBookService Books
        {
            get { return _books = new BookService(_context, _mapper); }
        }

        public ICategoryService Categories
        {
            get { return _categories = new CategoryService(_context, _mapper); }
        }

        public IAuthorService Authors
        {
            get { return _authors = new AuthorService(_context, _mapper); }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
