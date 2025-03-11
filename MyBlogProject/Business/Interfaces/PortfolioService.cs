using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _PortfolioRepository;
        public PortfolioService(IPortfolioRepository PortfolioRepository)
        {
            _PortfolioRepository = PortfolioRepository;
        }
        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await _PortfolioRepository.GetAllPortfolioAsync();
        }

        public async Task CreatePortfolioAsync(Portfolio Portfolio)
        {
            await _PortfolioRepository.AddAsync(Portfolio);
        }
        public async Task UpdatePortfolioAsync(Portfolio Portfolio)
        {
            var existingPortfolio = await _PortfolioRepository.GetByIdAsync(Portfolio.PortfolioId);
            if (existingPortfolio != null)
            {
               existingPortfolio.Description = Portfolio.Description;
               existingPortfolio.ImageUrl = Portfolio.ImageUrl;
                await _PortfolioRepository.UpdateAsync(existingPortfolio);
            }
        }
        public async Task DeletePortfolioAsync(int id)
        {
            var Portfolio = await _PortfolioRepository.GetByIdAsync(id);
            if (Portfolio != null)
            {
                await _PortfolioRepository.DeletePortfolioAsync(id);
            }
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int id)
        {
            return await _PortfolioRepository.GetByIdAsync(id);
        } 
    }
}
