using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IPortfolioDetailRepository
    {
        Task<IEnumerable<PortfolioDetail>> GetAllPortfolioDetailAsync();
        Task<PortfolioDetail> GetByIdAsync(int id);
        Task AddAsync(PortfolioDetail PortfolioDetail);
        Task UpdateAsync(PortfolioDetail PortfolioDetail);
        Task DeletePortfolioDetailAsync(int id);
    }
}
