using System.ComponentModel;
using Xamarin.Forms;
using BookApp.ViewModels;

namespace BookApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}