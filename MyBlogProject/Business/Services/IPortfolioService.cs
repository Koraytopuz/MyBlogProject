using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IPortfolioService
    {
        Task<Portfolio> GetPortfolioByIdAsync(int id);
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task CreatePortfolioAsync(Portfolio Portfolio);
        Task DeletePortfolioAsync(int id);
        Task UpdatePortfolioAsync(Portfolio Portfolio);
    }
}
