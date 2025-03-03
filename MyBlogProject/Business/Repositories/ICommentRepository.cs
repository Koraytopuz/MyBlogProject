using MyBlogProject.Business.Repositories;
using MyBlogProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogProject.Business.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        // Asenkron olarak tüm yorumları getirir
        Task<IEnumerable<Comment>> GetAllAsync();

        // ID'ye göre yorum getirir
        Task<Comment> GetByIdAsync(int id);

        // PostId'ye göre yorumları getirir
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);

        // Yorum ekler
        Task AddAsync(Comment entity);

        // Yorum günceller
        Task UpdateAsync(Comment entity);

        // Yorum siler
        Task DeleteAsync(Comment entity);

        // Bir kullanıcının tüm yorumlarını getirir
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId);
    }
}

