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

        protected override bool OnBackButtonPressed()
        {
            viewModel.BackCommand.Execute(null);
            return true;
        }
    }
}