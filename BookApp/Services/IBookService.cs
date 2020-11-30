using BookApp.Models;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IBookService
    {
        Task<Book[]> GetReviewedBooksAsync();
        Task<Book[]> FindBooksAsync(string query);
        Task ReviewBookAsync(Book book, string review);
    }
}
