using BookApp.Models;
using BookApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class BookListViewModel : BaseViewModel
    {
        IBookService _bookService;
        Book[] _books;

        public Book[] Books
        {
            get => _books;
            set => SetProperty(ref _books, value);
        }

        public BookListViewModel()
        {
            _bookService = DependencyService.Get<IBookService>();
            _ = InitializeAsync();
        }

        public override async Task InitializeAsync(object navigationData = null)
        {
            Books = await _bookService.GetReviewedBooksAsync();
        }
    }
}
