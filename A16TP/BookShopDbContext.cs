using A16TP.Models;
using Microsoft.EntityFrameworkCore;

namespace A16TP
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketBook> BasketBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Basket and Book
            modelBuilder.Entity<BasketBook>()
                .HasKey(bb => new { bb.BasketId, bb.BookId });

            modelBuilder.Entity<BasketBook>()
                .HasOne(bb => bb.Basket)
                .WithMany(b => b.BasketBooks)
                .HasForeignKey(bb => bb.BasketId);

            modelBuilder.Entity<BasketBook>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BasketBooks)
                .HasForeignKey(bb => bb.BookId);

            // Seed initial data will be added later
        }
    }
}