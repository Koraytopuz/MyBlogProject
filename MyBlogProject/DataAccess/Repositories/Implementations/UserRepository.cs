using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
        public class UserRepository : IUserRepository
        {
            private readonly MyBlogDbContext _myBlogDbContext;

            public UserRepository(MyBlogDbContext context)
            {
                _myBlogDbContext = context;
            }

            public async Task<List<User>> GetAllAsync()
            {
                return await _myBlogDbContext.Users.ToListAsync();
            }

            public async Task<User> GetByIdAsync(int id)
            {
                return await _myBlogDbContext.Users.FindAsync(id);
            }

            public async Task AddAsync(User user)
            {
                await _myBlogDbContext.Users.AddAsync(user);
                await _myBlogDbContext.SaveChangesAsync();
            }

            public async Task UpdateAsync(User user)  // Task olarak döndür
            {
            _myBlogDbContext.Users.Update(user);
            await _myBlogDbContext.SaveChangesAsync(); // **await ekle**
        }



        public async Task DeleteUserAsync(int id)
        {
            var user = await _myBlogDbContext.Users.FindAsync(id); // Kullanıcıyı bul
            if (user != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.Users.Remove(user);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }
        public async Task<User> GetByEmailAsync(string mail)
        {
            return await _myBlogDbContext.Users.FirstOrDefaultAsync(u => u.Mail == mail);
        }


        void IGenericRepository<User>.UpdateAsync(User entity)
{
    _myBlogDbContext.Users.Update(entity);
    _myBlogDbContext.SaveChangesAsync();
}

        public async void Delete(int id)
        {
            var user = await _myBlogDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _myBlogDbContext.Users.Remove(user);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }
    }
    }
