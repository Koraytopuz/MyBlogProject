using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBlogDbContext context) : base(context) { }

        public async Task<User> GetByEmailAsync(string mail)
        {
            return await _myBlogProject.FirstOrDefaultAsync(x => x.Mail == mail);
        }
    }
}