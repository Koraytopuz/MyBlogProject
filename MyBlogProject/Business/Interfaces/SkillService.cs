using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _SkillRepository;
        public SkillService(ISkillRepository SkillRepository)
        {
            _SkillRepository = SkillRepository;
        }
        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _SkillRepository.GetAllSkillAsync();
        }

        public async Task CreateSkillAsync(Skill Skill)
        {
            await _SkillRepository.AddAsync(Skill);
        }
        public async Task UpdateSkillAsync(Skill Skill)
        {
            var existingSkill = await _SkillRepository.GetByIdAsync(Skill.Id);
            if (existingSkill != null)
            {
               existingSkill.SkillName = Skill.SkillName;
               existingSkill.Value = Skill.Value;

                await _SkillRepository.UpdateAsync(existingSkill);
            }
        }
        public async Task DeleteSkillAsync(int id)
        {
            var Skill = await _SkillRepository.GetByIdAsync(id);
            if (Skill != null)
            {
                await _SkillRepository.DeleteSkillAsync(id);
            }
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _SkillRepository.GetByIdAsync(id);
        }
    
    }
}
