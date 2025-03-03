namespace MyBlogProject.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImageUrl { get; set; }


        // Foreign Key to User
        public int UserId { get; set; }  // Buradaki UserId alanı, User tablosu ile ilişkilidir.
        public User User { get; set; }  // User tablosu ile ilişkili navigasyon özelliği
    }

}
