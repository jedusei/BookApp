using BookApp.ViewModels;
using BookApp.Views.Base;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class FriendListTab : ContentView, ITabContentView
    {
        FriendListViewModel _viewModel;

        public FriendListTab()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FriendListViewModel();
        }

        public void OnStart()
        {
            _viewModel.OnStart();
        }
    }
}