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
        ObservableRangeCollection<Friend> _friends = new ObservableRangeCollection<Friend>(new Friend[] {
            new Friend
            {
                Name = "Rachel",
                ProfileImageUrl = "https://dieteticallyspeaking.com/wp-content/uploads/2017/01/profile-square.jpg",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,13,30,0)
                    }
                })
            },
        });

        public FriendService()
        {
            _friends.Add(_friends[0]);
            _friends.Add(_friends[0]);
            _friends.Add(_friends[0]);
            _friends.Add(_friends[0]);
            _friends.Add(_friends[0]);
        }

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
