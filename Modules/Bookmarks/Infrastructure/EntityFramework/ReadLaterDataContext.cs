using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadLater.Bookmarks.EntityFramework.Entities;
using System.Linq;

namespace ReadLater.Bookmarks.EntityFramework
{
    public class ReadLaterDataContext : IdentityDbContext

    {
        public ReadLaterDataContext(DbContextOptions<ReadLaterDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bookmark>()
            .HasOne(e => e.Category)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
