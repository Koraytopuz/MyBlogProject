using MyBlogProject.WebApı.Dtos.CommentDtos;

namespace MyBlogProject.Business.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllCommentsAsync();
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CommentDto commentDto);
        Task UpdateCommentAsync(CommentDto commentDto);
        Task DeleteCommentAsync(int id);
        Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId);
    }
}
