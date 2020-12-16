using BookApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IBookService
    {
        Task<ObservableCollection<Book>> GetReviewedBooksAsync();
        Task<Book[]> FindBooksAsync(string query);
        Task ReviewBookAsync(Book book, float rating);
    }
}
