using BookApp.Views.Base;

namespace BookApp.Views
{
    public partial class AddFriendsPage : BasePage
    {
        public AddFriendsPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddFriendsViewModel();
        }
    }
}