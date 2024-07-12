namespace bookproject.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task DeleteAsync(int Id);
        void Update(T entity);
        Task AddAsync(T entity);
    }
}
