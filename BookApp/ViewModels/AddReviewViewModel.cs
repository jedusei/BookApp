using BookApp.Models;
using BookApp.Services;
using System;
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

        public AddReviewViewModel()
        {
            if (!DesignMode.IsDesignModeEnabled)
                _bookService = DependencyService.Get<IBookService>();
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
    }
}
