using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);  // void değil, Task olmalı
        Task DeleteUserAsync(int id);
        Task<User> GetByEmailAsync(string mail);
    }
}
