using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public SkillRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(Skill Skill)
        {
            await _myBlogDbContext.Skills.AddAsync(Skill);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(int id)
        {
            var Skill = await _myBlogDbContext.Skills.FindAsync(id); // Kullanıcıyı bul
            if (Skill != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.Skills.Remove(Skill);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.Skills.FindAsync(id);
        }

        public async Task UpdateAsync(Skill Skill)
        {
            _myBlogDbContext.Skills.Update(Skill);
            _myBlogDbContext.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Skill>> GetAllSkillAsync()
        {
            return await _myBlogDbContext.Skills.ToListAsync();
        }
    }
}
