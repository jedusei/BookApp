using BookApp.ViewModels;
using BookApp.Views.Base;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class SettingsTab : ContentView, ITabContentView
    {
        SettingsViewModel _viewModel;

        public SettingsTab()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SettingsViewModel();
        }

        public void OnStart()
        {
            _viewModel.OnStart();
        }
    }
}