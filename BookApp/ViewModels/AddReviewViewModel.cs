using Acr.UserDialogs;
using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class AddReviewViewModel : BaseViewModel
    {
        const int RESULTS_LIST_ROW_HEIGHT = 50;
        const int MAX_VISIBLE_RESULTS_COUNT = 7;
        int _resultsListHeight;
        IBookService _bookService;
        Book[] _searchResults;
        string _searchText;
        int _currentPage;
        Book _selectedBook;
        float _rating = -1;
        bool _isFirstReview;

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value, onChanged: OnSearchTextChanged);
        }
        public int ResultsListHeight
        {
            get => _resultsListHeight;
            private set => SetProperty(ref _resultsListHeight, value);
        }
        public Book[] SearchResults
        {
            get => _searchResults;
            private set => SetProperty(ref _searchResults, value);
        }
        public int CurrentPage
        {
            get => _currentPage;
            private set => SetProperty(ref _currentPage, value, onChanged: (NextCommand as Command).ChangeCanExecute);
        }
        public Book SelectedBook
        {
            get => _selectedBook;
            private set => SetProperty(ref _selectedBook, value);
        }
        public float Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value, onChanged: (NextCommand as Command).ChangeCanExecute);
        }
        public ICommand NextCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand SelectBookCommand { get; private set; }
        public ICommand OpenWebLinkCommand { get; private set; }

        public AddReviewViewModel()
        {
            if (!DesignMode.IsDesignModeEnabled)
                _bookService = DependencyService.Get<IBookService>();

            SelectBookCommand = new Command<CollectionView>(SelectBook);
            NextCommand = new Command(Next, () => _currentPage == 1 && _rating >= 0);
            BackCommand = new Command(GoBack);
            OpenWebLinkCommand = new Command(OpenWebLink);
        }

        public override Task InitializeAsync(object navigationData)
        {
            var args = navigationData as AddReviewPage.Args;
            if (args != null)
                _isFirstReview = args.IsFirstReview;

            return Task.CompletedTask;
        }

        async void OnSearchTextChanged()
        {
            string query = _searchText.Trim();
            if (query.Length == 0)
                SearchResults = new Book[0];
            else
            {
                SearchResults = await _bookService.FindBooksAsync(query);
                ResultsListHeight = RESULTS_LIST_ROW_HEIGHT * Math.Min(SearchResults.Length, MAX_VISIBLE_RESULTS_COUNT);
            }
        }

        void SelectBook(CollectionView collectionView)
        {
            if (collectionView.SelectedItem != null)
            {
                SelectedBook = collectionView.SelectedItem as Book;
                collectionView.SelectedItem = null;
                NextCommand.Execute(null);
            }
        }

        async void OpenWebLink()
        {
            try
            {
                await Browser.OpenAsync(_selectedBook.WebUrl);
            }
            catch { }
        }

        async void Next()
        {
            if (_currentPage == 0)
            {
                CurrentPage = 1;
                SearchText = string.Empty;
                Rating = -1;
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Please wait...");
                await _bookService.ReviewBookAsync(_selectedBook, _rating);
                UserDialogs.Instance.HideLoading();
                if (_isFirstReview)
                    await _navigationService.GoToPageAsync<ReviewThanksPage>(removeCurrentPage: true);
                else
                    await _navigationService.GoBackAsync();
            }
        }

        async void GoBack()
        {
            if (_currentPage == 1)
                CurrentPage = 0;
            else
                await _navigationService.GoBackAsync();
        }
    }
}
