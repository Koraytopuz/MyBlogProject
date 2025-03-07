using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<SocialMedia>> GetAllAsync();
        Task<SocialMedia> GetByIdAsync(int id);
        Task AddAsync(SocialMedia socialMedia);
        Task UpdateAsync(SocialMedia socialMedia);
        Task DeleteAsync(int id);
    }
}
