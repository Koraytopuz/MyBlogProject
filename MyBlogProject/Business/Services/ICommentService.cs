using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.CommentDtos;

namespace MyBlogProject.Business.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(int id);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId);
    }
}
