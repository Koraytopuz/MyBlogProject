using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string mail);
    }
}
