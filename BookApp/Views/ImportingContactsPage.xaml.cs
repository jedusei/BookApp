namespace BookApp.Views
{
    public partial class ImportingContactsPage : Base.BasePage
    {
        public ImportingContactsPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}