using ImageGram.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageGram.Infrastructure.Data
{
    public class ImageGramDBContext : DbContext
    {
        public ImageGramDBContext(DbContextOptions<ImageGramDBContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}