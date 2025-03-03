using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class PostRepository:IPostRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public PostRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;

            // Burada manuel olarak Id değeri atanmamalı, SQL Server otomatik olarak arttıracak.
            await _myBlogDbContext.Posts.AddAsync(post);
            await _myBlogDbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var post = await _myBlogDbContext.Posts.FindAsync(id);
            if (post != null)
            {
                _myBlogDbContext.Posts.Remove(post);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllAsync()
        {

            return await _myBlogDbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
           return await _myBlogDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Post post)
        {
            _myBlogDbContext.Posts.Update(post);
           await _myBlogDbContext.SaveChangesAsync();
        }
    }
}
