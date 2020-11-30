using BookApp.Views.Base;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class BookListTab : ContentView, ITabContentView
    {
        public BookListTab()
        {
            InitializeComponent();
        }

        public void OnStart()
        {
            viewModel.OnStart();
        }
    }
}