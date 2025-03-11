using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface ISkillService
    {
        Task<Skill> GetSkillByIdAsync(int id);
        Task<IEnumerable<Skill>> GetAllAsync();
        Task CreateSkillAsync(Skill Skill);
        Task DeleteSkillAsync(int id);
        Task UpdateSkillAsync(Skill Skill);
    }
}
