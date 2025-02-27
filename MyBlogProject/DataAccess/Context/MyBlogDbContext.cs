using Microsoft.EntityFrameworkCore;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Context
{
    public class MyBlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=KRYTOPUZ\\SQL1;initial Catalog=CarBookDb;integrated Security=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("Server=PC003BTX50\\SQLEXPRESS;Database=BlogProjectDb;integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true");


        }

        public async Task<User> FirstOrDefaultAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }   
}

