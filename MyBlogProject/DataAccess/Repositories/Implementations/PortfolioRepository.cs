using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public PortfolioRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(Portfolio Portfolio)
        {
            await _myBlogDbContext.Portfolios.AddAsync(Portfolio);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var Portfolio = await _myBlogDbContext.Portfolios.FindAsync(id); // Kullanıcıyı bul
            if (Portfolio != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.Portfolios.Remove(Portfolio);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.Portfolios.FindAsync(id);
        }

        public async Task UpdateAsync(Portfolio Portfolio)
        {
            _myBlogDbContext.Portfolios.Update(Portfolio);
            _myBlogDbContext.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Portfolio>> GetAllPortfolioAsync()
        {
            return await _myBlogDbContext.Portfolios.ToListAsync();
        }
    }
}
