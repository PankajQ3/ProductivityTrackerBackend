using Microsoft.EntityFrameworkCore;
using ProductivityTrackerBackend.Models;

namespace ProductivityTrackerBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User → Goals (One-to-Many)
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Goal → Items (One-to-Many)
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Goal)
                .WithMany(g => g.Items)
                .HasForeignKey(i => i.GoalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Item → TimeLogs (One-to-Many)
            modelBuilder.Entity<TimeLog>()
                .HasOne(tl => tl.Item)
                .WithMany(i => i.TimeLogs)
                .HasForeignKey(tl => tl.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
