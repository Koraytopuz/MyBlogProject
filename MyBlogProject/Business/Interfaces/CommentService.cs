using AutoMapper;
using MyBlogProject.Business.Interfaces.Repositories;
using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.CommentDtos;

namespace MyBlogProject.Business.Interfaces
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _commentRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Comment comment)
        {
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _commentRepository.UpdateAsync(comment);
            await _commentRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment != null)
            {
                await _commentRepository.DeleteAsync(comment);
                await _commentRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _commentRepository.GetCommentsByPostIdAsync(postId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(int userId)
        {
            return await _commentRepository.GetCommentsByUserIdAsync(userId);
        }
    }
}
