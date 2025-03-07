using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface ISocialMediaRepository : IGenericRepository<SocialMedia>
    {
        Task<IEnumerable<SocialMedia>> GetAllAsync();
        Task<SocialMedia> GetByIdAsync(int id);
        Task AddAsync(SocialMedia socialMedia);
        Task UpdateAsync(SocialMedia socialMedia);
        Task DeleteAsync(int id);

    }
}
