using Microsoft.Extensions.Hosting;

namespace MyBlogProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public Post Posts { get; set; }
    }
}

