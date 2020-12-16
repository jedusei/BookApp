using BookApp.Views.Base;

namespace BookApp.Views
{
    public partial class AddReviewPage : BasePage
    {
        public class Args
        {
            public bool IsFirstReview { get; set; }
        }

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