using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MyBlogDbContext _myBlogDbContext;
        protected DbSet<T> _myBlogProject;

        public GenericRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
            _myBlogProject = _myBlogDbContext.Set<T>();  // DbSet'in otomatik olarak tanımlanmasını sağlıyoruz
        }

        public async Task<List<T>> GetAllAsync() => await _myBlogProject.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _myBlogProject.FindAsync(id);

        public async Task AddAsync(T entity) => await _myBlogProject.AddAsync(entity);

        public async Task SaveAsync() => await _myBlogDbContext.SaveChangesAsync();

        public void UpdateAsync(T entity)
        {
            _myBlogDbContext.Update(entity); // Entity güncellemesi
        }

        public void Delete(int id)
        {
            var entity = _myBlogProject.Find(id);  // ID ile entity'yi buluyoruz
            if (entity != null)
            {
                _myBlogProject.Remove(entity);  // Bulunan entity'yi siliyoruz
            }
        }
    }
}