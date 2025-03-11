using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetAllPortfolioAsync();
        Task<Portfolio> GetByIdAsync(int id);
        Task AddAsync(Portfolio Portfolio);
        Task UpdateAsync(Portfolio Portfolio);
        Task DeletePortfolioAsync(int id);
    }
}
