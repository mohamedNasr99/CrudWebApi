using bookproject.Data;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await GetAsync(Id);
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
