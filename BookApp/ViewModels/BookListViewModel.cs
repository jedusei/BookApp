using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class BookListViewModel : BaseViewModel
    {
        IBookService _bookService;
        LoadStatus _loadStatus;
        ObservableCollection<Book> _books;

        public LoadStatus LoadStatus
        {
            get => _loadStatus;
            private set => SetProperty(ref _loadStatus, value);
        }
        public ObservableCollection<Book> Books
        {
            get => _books;
            set => SetProperty(ref _books, value);
        }
        public ICommand AddReviewCommand { get; private set; }

        public BookListViewModel()
        {
            if (!DesignMode.IsDesignModeEnabled)
                _bookService = DependencyService.Get<IBookService>();

            AddReviewCommand = new Command(async () =>
            {
                await _navigationService.GoToPageAsync<AddReviewPage>(new AddReviewPage.Args
                {
                    IsFirstReview = _books.Count == 0
                });
            });
        }

        public override async void OnStart()
        {
            LoadStatus = LoadStatus.Loading;
            Books = await _bookService.GetReviewedBooksAsync();
            LoadStatus = LoadStatus.Loaded;
        }
    }
}
