using Microsoft.EntityFrameworkCore;
using OnlineForestAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OnlineForestAPI.Data
{
    public class ForestOnlineDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<TokenEarn> TokenEarns { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<LandCategory> LandCategories { get; set; }
        public DbSet<TreeCategory> TreeCategories { get; set; }

        // Constructor để cấu hình connection string cho DbContext
        public ForestOnlineDbContext(DbContextOptions<ForestOnlineDbContext> options) : base(options)
        {
        }

        // Cấu hình quan hệ giữa các bảng và các thuộc tính
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Quan hệ giữa User và Land: Một User có thể có nhiều Land
            modelBuilder.Entity<User>()
                .HasMany(u => u.Lands)
                .WithOne()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ giữa User và TokenEarn: Một User có thể nhận nhiều TokenEarn
            modelBuilder.Entity<User>()
                .HasMany(u => u.TokenEarnings)
                .WithOne()
                .HasForeignKey(te => te.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Thay đổi thành NoAction để tránh chu trình cascade

            // Cấu hình mối quan hệ giữa Tree và Land
            modelBuilder.Entity<Tree>()
                .HasOne(t => t.Land)  // Tree có một Land
                .WithMany(l => l.Trees)  // Land có nhiều Tree
                .HasForeignKey(t => t.LandId)  // Chỉ định khóa ngoại
                .OnDelete(DeleteBehavior.Cascade);  // Hành động khi xóa (Cascade)

            // Quan hệ giữa Land và LandCategory: Một LandCategory có thể có nhiều Land
            modelBuilder.Entity<Land>()
                .HasOne(l => l.LandCategory)
                .WithMany(lc => lc.Lands)
                .HasForeignKey(l => l.LandCategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Thay SET NULL bằng CASCADE

            // Quan hệ giữa Tree và TreeCategory: Một TreeCategory có thể có nhiều Tree
            modelBuilder.Entity<Tree>()
                .HasOne(t => t.TreeCategory)
                .WithMany(tc => tc.Trees)
                .HasForeignKey(t => t.TreeCategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Thay SET NULL bằng CASCADE

            // Quan hệ giữa Tree và TokenEarn: Một Tree sẽ có một TokenEarn
            modelBuilder.Entity<Tree>()
                .HasOne(t => t.TokenEarn)
                .WithOne(te => te.Tree)
                .HasForeignKey<TokenEarn>(te => te.TreeId) // Khóa ngoại liên kết
                .OnDelete(DeleteBehavior.NoAction); // Thay đổi thành NoAction để tránh xóa TokenEarn khi xóa Tree

            // Cấu hình các thuộc tính
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Tree>()
                .Property(t => t.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<TokenEarn>()
                .Property(te => te.Reason)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Land>()
                .Property(l => l.LastPlanted)
                .IsRequired();

            modelBuilder.Entity<LandCategory>()
                .Property(lc => lc.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<LandCategory>()
                .Property(lc => lc.MaxSlots)
                .IsRequired();

            modelBuilder.Entity<LandCategory>()
                .Property(lc => lc.LandPrice)
                .IsRequired();

            modelBuilder.Entity<TreeCategory>()
                .Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TreeCategory>()
                .Property(tc => tc.TreePrice)
                .IsRequired();

            modelBuilder.Entity<TreeCategory>()
                .Property(tc => tc.GrowthTime)
                .IsRequired();
        }
    }

}
