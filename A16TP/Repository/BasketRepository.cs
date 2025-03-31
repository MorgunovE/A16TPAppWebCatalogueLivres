using A16TP.Models;
using Microsoft.EntityFrameworkCore;

namespace A16TP.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BookShopDbContext _context;

        public BasketRepository(BookShopDbContext context)
        {
            _context = context;
        }

        public async Task<Basket?> GetByIdAsync(long id)
        {
            return await _context.Baskets.FindAsync(id);
        }

        public async Task<Basket?> GetByUserIdAsync(long userId)
        {
            return await _context.Baskets
                .Include(b => b.BasketBooks)
                .ThenInclude(bb => bb.Book)
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task<IEnumerable<Book>> GetBooksInBasketAsync(long basketId)
        {
            var basketBooks = await _context.BasketBooks
                .Where(bb => bb.BasketId == basketId)
                .Include(bb => bb.Book)
                .ToListAsync();

            return basketBooks.Select(bb => bb.Book).OfType<Book>().ToList();
        }

        public async Task AddBookToBasketAsync(long basketId, long bookId)
        {
            var existingItem = await _context.BasketBooks
                .FirstOrDefaultAsync(bb => bb.BasketId == basketId && bb.BookId == bookId);

            if (existingItem == null)
            {
                _context.BasketBooks.Add(new BasketBook { BasketId = basketId, BookId = bookId });
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromBasketAsync(long basketId, long bookId)
        {
            var item = await _context.BasketBooks
                .FirstOrDefaultAsync(bb => bb.BasketId == basketId && bb.BookId == bookId);

            if (item != null)
            {
                _context.BasketBooks.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearBasketAsync(long basketId)
        {
            var items = await _context.BasketBooks
                .Where(bb => bb.BasketId == basketId)
                .ToListAsync();

            _context.BasketBooks.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}