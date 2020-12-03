using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class FriendListViewModel : BaseViewModel
    {
        IFriendService _friendService;
        LoadStatus _loadStatus;

        public LoadStatus LoadStatus
        {
            get => _loadStatus;
            set => SetProperty(ref _loadStatus, value);
        }
        public ObservableCollection<Friend> Friends { get; private set; }
        public bool ShowList => (_loadStatus != LoadStatus.Loading) && (Friends?.Count != 0);
        public bool ShowEmptyView => (_loadStatus != LoadStatus.Loading) && (Friends?.Count == 0);
        public ICommand AddFriendsCommand { get; private set; }
        public ICommand OpenChatCommand { get; private set; }

        public FriendListViewModel()
        {
            _friendService = DependencyService.Get<IFriendService>();
            AddFriendsCommand = new AsyncCommand(() => _navigationService.GoToPageAsync<AddFriendsPage>());
            OpenChatCommand = new AsyncCommand<Friend>(async (friend) =>
            {
                await Task.Delay(300);
                await _navigationService.GoToPageAsync<ChatPage>(new ChatPage.Args
                {
                    Friend = friend
                });
            });
        }

        public override async void OnStart()
        {
            base.OnStart();
            LoadStatus = LoadStatus.Loading;

            Friends = await _friendService.GetFriendsAsync();

            LoadStatus = LoadStatus.Loaded;

            Friends.CollectionChanged += OnFriendListChanged;
            OnPropertyChanged(nameof(Friends));
            OnPropertyChanged(nameof(ShowList));
            OnPropertyChanged(nameof(ShowEmptyView));
        }

        void OnFriendListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ShowList));
            OnPropertyChanged(nameof(ShowEmptyView));
        }
    }
}
