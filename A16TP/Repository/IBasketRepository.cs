using A16TP.Models;

namespace A16TP.Repository
{
    public interface IBasketRepository
    {
        Task<Basket?> GetByIdAsync(long id);
        Task<Basket?> GetByUserIdAsync(long userId);
        Task<IEnumerable<Book>> GetBooksInBasketAsync(long basketId);
        Task AddBookToBasketAsync(long basketId, long bookId);
        Task RemoveBookFromBasketAsync(long basketId, long bookId);
        Task ClearBasketAsync(long basketId);
    }
}