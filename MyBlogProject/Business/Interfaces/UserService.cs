using MyBlogProject.Business.Services;
using MyBlogProject.Business.Repositories;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        async Task<IEnumerable<User>> IUserService.GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync(); 
        }

        public async Task<User> GetByEmailAsync(string mail)
        {
            return await _userRepository.GetByEmailAsync(mail);
        }
    }
}
