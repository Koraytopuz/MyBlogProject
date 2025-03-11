using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IPortfolioDetailService
    {
        Task<PortfolioDetail> GetPortfolioDetailByIdAsync(int id);
        Task<IEnumerable<PortfolioDetail>> GetAllAsync();
        Task CreatePortfolioDetailAsync(PortfolioDetail PortfolioDetail);
        Task DeletePortfolioDetailAsync(int id);
        Task UpdatePortfolioDetailAsync(PortfolioDetail PortfolioDetail);
    }
}
