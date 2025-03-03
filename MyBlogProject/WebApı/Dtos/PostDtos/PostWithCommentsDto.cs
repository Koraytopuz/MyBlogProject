using MyBlogProject.WebApı.Dtos.CommentDtos;

namespace MyBlogProject.WebApı.Dtos.PostDtos
{
    public class PostWithCommentsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
