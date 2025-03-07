using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task AddAsync(SocialMedia socialMedia)
        {
            await _socialMediaRepository.AddAsync(socialMedia);
           
        }

        public async Task DeleteAsync(int id)
        {
            await _socialMediaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SocialMedia>> GetAllAsync()
        {
            return await _socialMediaRepository.GetAllAsync();
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _socialMediaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SocialMedia socialMedia)
        {
            await _socialMediaRepository.UpdateAsync(socialMedia);
        }
    }
}
