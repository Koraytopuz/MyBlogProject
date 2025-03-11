using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class PortfolioDetailRepository : IPortfolioDetailRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public PortfolioDetailRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(PortfolioDetail PortfolioDetail)
        {
            await _myBlogDbContext.PortfolioDetails.AddAsync(PortfolioDetail);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeletePortfolioDetailAsync(int id)
        {
            var PortfolioDetail = await _myBlogDbContext.PortfolioDetails.FindAsync(id); // Kullanıcıyı bul
            if (PortfolioDetail != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.PortfolioDetails.Remove(PortfolioDetail);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<PortfolioDetail> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.PortfolioDetails.FindAsync(id);
        }

        public async Task UpdateAsync(PortfolioDetail PortfolioDetail)
        {
            _myBlogDbContext.PortfolioDetails.Update(PortfolioDetail);
            _myBlogDbContext.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<PortfolioDetail>> GetAllPortfolioDetailAsync()
        {
            return await _myBlogDbContext.PortfolioDetails.ToListAsync();
        }
    }
}
