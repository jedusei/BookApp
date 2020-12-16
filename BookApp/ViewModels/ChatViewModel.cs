using BookApp.Models;
using BookApp.Views;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookApp.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public Friend Friend { get; private set; }
        public ICommand BackCommand { get; set; }

        public ChatViewModel()
        {
            BackCommand = new AsyncCommand(() => _navigationService.GoBackAsync());
        }

        public override Task InitializeAsync(object navigationData)
        {
            var args = navigationData as ChatPage.Args;
            Friend = args.Friend;
            OnPropertyChanged(nameof(Friend));

            return Task.CompletedTask;
        }
    }
}
