using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class AboutRepository : IAboutRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public AboutRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(About about)
        {
            await _myBlogDbContext.Abouts.AddAsync(about);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var About = await _myBlogDbContext.Abouts.FindAsync(id); // Kullanıcıyı bul
            if (About != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.Abouts.Remove(About);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.Abouts.FindAsync(id);
        }

        public async Task UpdateAsync(About about)
        {
            _myBlogDbContext.Abouts.Update(about);
           await _myBlogDbContext.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }

     

        public async Task<IEnumerable<About>> GetAllAboutAsync()
        {
            return await _myBlogDbContext.Abouts.ToListAsync();
        }
   
    }
}

