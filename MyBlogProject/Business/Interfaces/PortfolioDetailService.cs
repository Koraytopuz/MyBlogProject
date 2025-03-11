using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class PortfolioDetailService : IPortfolioDetailService
    {
        private readonly IPortfolioDetailRepository _PortfolioDetailRepository;
        public PortfolioDetailService(IPortfolioDetailRepository PortfolioDetailRepository)
        {
            _PortfolioDetailRepository = PortfolioDetailRepository;
        }
        public async Task<IEnumerable<PortfolioDetail>> GetAllAsync()
        {
            return await _PortfolioDetailRepository.GetAllPortfolioDetailAsync();
        }

        public async Task CreatePortfolioDetailAsync(PortfolioDetail PortfolioDetail)
        {
            await _PortfolioDetailRepository.AddAsync(PortfolioDetail);
        }
        public async Task UpdatePortfolioDetailAsync(PortfolioDetail PortfolioDetail)
        {
            var existingPortfolioDetail = await _PortfolioDetailRepository.GetByIdAsync(PortfolioDetail.Id);
            if (existingPortfolioDetail != null)
            {
                existingPortfolioDetail.Title = PortfolioDetail.Title;
                existingPortfolioDetail.ProjectTitle = PortfolioDetail.ProjectTitle;
                existingPortfolioDetail.Description = PortfolioDetail.Description;
                existingPortfolioDetail.Detail = PortfolioDetail.Detail;
                existingPortfolioDetail.BigImageUrl = PortfolioDetail.BigImageUrl;
                existingPortfolioDetail.ProjectUrl = PortfolioDetail.ProjectUrl;
                
                await _PortfolioDetailRepository.UpdateAsync(existingPortfolioDetail);
            }
        }
        public async Task DeletePortfolioDetailAsync(int id)
        {
            var PortfolioDetail = await _PortfolioDetailRepository.GetByIdAsync(id);
            if (PortfolioDetail != null)
            {
                await _PortfolioDetailRepository.DeletePortfolioDetailAsync(id);
            }
        }

        public async Task<PortfolioDetail> GetPortfolioDetailByIdAsync(int id)
        {
            return await _PortfolioDetailRepository.GetByIdAsync(id);
        }

    }
}
