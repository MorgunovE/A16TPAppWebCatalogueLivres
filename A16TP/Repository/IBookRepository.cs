using A16TP.Models;

namespace A16TP.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(long id);
        Task<IEnumerable<Book>> GetByGenreAsync(string genre);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(long id);
    }
}