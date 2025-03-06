using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IAboutService
    {
        Task<About> GetAboutByIdAsync(int id);
        Task<IEnumerable<About>> GetAllAsync();
        Task CreateAboutAsync(About About);
        Task DeleteAboutAsync(int id);
        Task UpdateAboutAsync(About About);
    }
}
