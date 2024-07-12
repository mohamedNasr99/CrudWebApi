namespace bookproject.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookService Books { get; }
        public ICategoryService Categories { get; }
        public IAuthorService Authors { get; }
    }
}
