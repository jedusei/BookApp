using BookApp.Models;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.FriendService))]
namespace BookApp.Services
{
    class FriendService : IFriendService
    {
        ObservableRangeCollection<Friend> _friends = new ObservableRangeCollection<Friend>();

        public async Task AddFriendsAsync(params Friend[] friends)
        {
            await Task.Delay(1500);
            _friends.AddRange(friends);
        }

        public async Task<ObservableCollection<Friend>> GetFriendsAsync()
        {
            await Task.Delay(1500);
            return _friends;
        }
    }
}
