using bookproject.Data;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBookService _books;
        private ICategoryService _categories;
        private IAuthorService _authors;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IBookService Books
        {
            get {return _books = new BookService(_context); }
        }

        public ICategoryService Categories
        {
            get { return _categories = new CategoryService(_context); }
        }

        public IAuthorService Authors
        {
            get { return _authors = new AuthorService(_context); }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
