using BookApp.Models;
using BookApp.Services;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class BookListViewModel : BaseViewModel
    {
        IBookService _bookService;
        LoadStatus _loadStatus;
        Book[] _books;

        public LoadStatus LoadStatus
        {
            get => _loadStatus;
            private set => SetProperty(ref _loadStatus, value);
        }

        public Book[] Books
        {
            get => _books;
            set => SetProperty(ref _books, value);
        }

        public BookListViewModel()
        {
            if (!DesignMode.IsDesignModeEnabled)
                _bookService = DependencyService.Get<IBookService>();
        }

        public override async void OnStart()
        {
            LoadStatus = LoadStatus.Loading;
            Books = await _bookService.GetReviewedBooksAsync();
            LoadStatus = LoadStatus.Loaded;
        }
    }
}
