using BookApp.Models;
using BookApp.Services;
using System;
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
        int _currentPage = 1;
        Book _selectedBook;
        float _rating = -1;

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
            private set => SetProperty(ref _currentPage, value);
        }
        public Book SelectedBook
        {
            get => _selectedBook;
            private set => SetProperty(ref _selectedBook, value);
        }
        public float Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }
        public ICommand NextCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand SelectBookCommand { get; private set; }
        public ICommand OpenWebLinkCommand { get; private set; }

        public AddReviewViewModel()
        {
            if (!DesignMode.IsDesignModeEnabled)
                _bookService = DependencyService.Get<IBookService>();

            SelectBookCommand = new Command<Book>(SelectBook);
            NextCommand = new Command(Next);
            BackCommand = new Command(GoBack);
            OpenWebLinkCommand = new Command(OpenWebLink);

            SelectedBook = new Book
            {
                Title = "Pet Sematary",
                Author = "Stephen King",
                Description = "The road in front of Dr. Louis Creed's rural Maine home frequently claims the lives of neighborhood pets. Louis has recently moved from Chicago to Ludlow with his wife Rachel, their children and pet cat. Near their house, local children have created a cemetery for the dogs and cats killed by the steady stream of transports on the busy highway. Deeper in the woods lies another graveyard, an ancient Indian burial ground whose sinister properties Louis discovers when the family cat is killed.",
                CoverImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1477286232l/32733787.jpg",// "https://i1.wp.com/dajjeh.com/wp-content/uploads/2018/07/pet-sematary-565x1024.jpg?fit=565%2C1024&ssl=1",
                Rating = 4.68f,
                ReviewCount = 2464,
                WebUrl = "https://stephenking.com/works/novel/pet-sematary.html"
            };
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

        void SelectBook(Book book)
        {
            SelectedBook = book;
            NextCommand.Execute(null);
        }

        async void OpenWebLink()
        {
            try
            {
                await Browser.OpenAsync(_selectedBook.WebUrl);
            }
            catch { }
        }

        void Next()
        {
            if (_currentPage == 0)
            {
                CurrentPage = 1;
                SearchText = string.Empty;
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
