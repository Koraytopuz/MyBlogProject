using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllSkillAsync();
        Task<Skill> GetByIdAsync(int id);
        Task AddAsync(Skill Skill);
        Task UpdateAsync(Skill Skill);
        Task DeleteSkillAsync(int id);
    }
}
