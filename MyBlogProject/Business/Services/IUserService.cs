using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(User user);
        Task<User> GetByEmailAsync(string mail);
    }
}
