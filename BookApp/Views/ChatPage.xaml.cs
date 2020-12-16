using BookApp.Models;
using BookApp.ViewModels;

namespace BookApp.Views
{
    public partial class ChatPage : Base.BasePage
    {
        public class Args
        {
            public Friend Friend { get; set; }
        }

        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }
    }
}