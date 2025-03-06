using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAboutAsync();
        Task<About> GetByIdAsync(int id);
        Task AddAsync(About About);
        Task UpdateAsync(About About); 
        Task DeleteAboutAsync(int id);
    }
}
