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
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.AddAsync(comment);
        }

        public async Task UpdateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment != null)
            {
                await _commentRepository.DeleteAsync(comment);
            }
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }
    }
}
