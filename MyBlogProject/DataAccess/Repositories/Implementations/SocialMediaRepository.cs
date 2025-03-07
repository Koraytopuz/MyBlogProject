using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class SocialMediaRepository : ISocialMediaRepository, IGenericRepository<SocialMedia>
    {
        private readonly MyBlogDbContext _context;

        public SocialMediaRepository(MyBlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SocialMedia socialMedia)
        {
            await _context.SocialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            var socialMedia = _context.SocialMedias.Find(id);
            if (socialMedia != null)
            {
                _context.SocialMedias.Remove(socialMedia);
            }
        }

      
        public  async Task DeleteAsync(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia != null)
            {
                _context.SocialMedias.Remove(socialMedia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SocialMedia>> GetAllAsync()
        {
            return await _context.SocialMedias.ToListAsync();
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _context.SocialMedias.FindAsync(id);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            await _context.SaveChangesAsync();
        }

        async Task<List<SocialMedia>> IGenericRepository<SocialMedia>.GetAllAsync()
        {
            return await _context.SocialMedias.ToListAsync();
        }

        void IGenericRepository<SocialMedia>.UpdateAsync(SocialMedia entity)
        {
            UpdateAsync(entity);
        }
    }
}
