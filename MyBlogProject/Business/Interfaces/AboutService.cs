using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class AboutService: IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await _aboutRepository.GetAllAboutAsync();
        }
      
        public async Task CreateAboutAsync(About About)
        {
            await _aboutRepository.AddAsync(About);
        }
        public async Task UpdateAboutAsync(About About)
        {
            var existingAbout = await _aboutRepository.GetByIdAsync(About.AboutId);
            if (existingAbout != null)
            {
                existingAbout.Title = About.Title;
                existingAbout.Description = About.Description;
                existingAbout.Details = About.Details;
                await _aboutRepository.UpdateAsync(existingAbout);
            }
        }
        public async Task DeleteAboutAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);
            if (about != null)
            {
                await _aboutRepository.DeleteAboutAsync(id);
            }
        }

        public async Task<About> GetAboutByIdAsync(int id)
        {
           return await _aboutRepository.GetByIdAsync(id);
        }
    }
}