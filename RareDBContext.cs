using Microsoft.EntityFrameworkCore;
using NetflixRareBackend.Data;
using NetflixRareBackend.Models;

namespace NetflixRareBackend
{
    public class RareDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public RareDbContext(DbContextOptions<RareDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reaction>().HasData(ReactionData.Reactions);
            modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
            modelBuilder.Entity<Comment>().HasData(CommentData.Comments);
            modelBuilder.Entity<Subscription>().HasData(SubscriptionData.Subscriptions);
            modelBuilder.Entity<Tag>().HasData(TagData.Tags);
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Post>().HasData(PostData.Posts);
        }

    }
}
