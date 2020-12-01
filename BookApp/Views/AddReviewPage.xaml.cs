using BookApp.Models;
using BookApp.Views.Base;

namespace BookApp.Views
{
    public partial class AddReviewPage : BasePage
    {
        public AddReviewPage()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            viewModel.SelectBookCommand.Execute(e.CurrentSelection[0] as Book);
        }
    }
}