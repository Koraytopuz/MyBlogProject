using Microsoft.EntityFrameworkCore;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Context
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User) // Bir Post'un bir User'ı var.
                .WithMany(u => u.Posts) // Bir User'ın birden fazla Post'u olabilir.
                .HasForeignKey(p => p.UserId) // Foreign Key olarak Post tablosundaki UserId'yi kullan.
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse Post'ları da silinsin.

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string? connectionString = configuration.GetConnectionString("DefaultConnection");

                if (connectionString != null)
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                }
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SocialMedia> SocialMedias  { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioDetail> PortfolioDetails { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}   