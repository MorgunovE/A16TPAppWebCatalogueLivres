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

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Basket> Baskets { get; set; } = default!;
        public DbSet<BasketBook> BasketBooks { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table name configurations - map to existing tables
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Book>().ToTable("Livre");
            modelBuilder.Entity<Basket>().ToTable("Basket");
            modelBuilder.Entity<BasketBook>().ToTable("Basket_Livre");

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

        }
    }
}