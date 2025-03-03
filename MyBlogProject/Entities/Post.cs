﻿namespace MyBlogProject.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }  // Foreign Key
        public User User { get; set; }   // Navigasyon özelliği
    }

}
