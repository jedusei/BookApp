using BookApp.ViewModels;
using BookApp.Views.Base;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class BookListTab : ContentView, ITabContentView
    {
        BookListViewModel _viewModel;

        public BookListTab()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BookListViewModel();
        }

        public void OnStart()
        {
            _viewModel.OnStart();
        }
    }
}