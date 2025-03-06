namespace MyBlogProject.WebApı.Dtos.CommentDtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Mail { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
       
    }
}
