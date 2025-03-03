using MyBlogProject.WebApı.Dtos.PostDtos;

namespace MyBlogProject.WebApı.Dtos.UserDtos
{
    public class UserWithPostsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}
