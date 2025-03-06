namespace MyBlogProject.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // İlişkiler
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
