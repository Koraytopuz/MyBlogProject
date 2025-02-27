using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.DataAccess.Context;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        protected readonly MyBlogDbContext _myBlogDbContext;
        protected DbSet<T> _myBlogProject;
        protected MyBlogDbContext context;

        public GenericRepository(MyBlogDbContext myBlogDbContext, DbSet<T> dbSet)
        {
            _myBlogDbContext = myBlogDbContext;
            _myBlogProject = dbSet;
        }

        public GenericRepository(MyBlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _myBlogProject.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _myBlogProject.FindAsync(id);

        public async Task AddAsync(T entity) => await _myBlogProject.AddAsync(entity);

        public void Update(T entity) => _myBlogProject.Update(entity);

        public void Delete(T entity) => _myBlogProject.Remove(entity);

        public async Task SaveAsync() => await _myBlogDbContext.SaveChangesAsync();

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<T>> IGenericRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<T>.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
