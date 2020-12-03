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
            new Friend
            {
                Name = "Tom",
                ProfileImageUrl = "https://darylh.com/wp-content/uploads/2017/05/Profile-Picture-Square.jpg",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,9,30,0)
                    }
                })
            },
            new Friend
            {
                Name = "Anna",
                ProfileImageUrl = "https://th.bing.com/th/id/OIP.dFWozadKXRMaXcczQyDIwgHaHa?pid=Api&rs=1",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,8,15,0)
                    }
                })
            },
            new Friend
            {
                Name = "Brad",
                ProfileImageUrl = "https://th.bing.com/th/id/OIP.jcRbSaarQNTnJveKfWVQaAHaHa?pid=Api&w=1024&h=1024&rs=1",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,8,23,0)
                    }
                })
            },
            new Friend
            {
                Name = "Kristen",
                ProfileImageUrl = "https://th.bing.com/th/id/OIP.CPEgIDN1Y8HhgR-uAZP-uQHaHa?pid=Api&w=300&h=300&rs=1",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,8,03,0)
                    }
                })
            },
            new Friend
            {
                Name = "Amy",
                ProfileImageUrl = "https://th.bing.com/th/id/OIP.m-e-s5X-7gYySbTaRrcKkAHaHa?pid=Api&w=540&h=540&rs=1",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        Content = "Quisque dictum varius arcu, eu scelerisque arcu consectetur ut. Duis dapibus nulla vitae ipsum mattis porttitor eget suscipit tellus.",
                        DateCreated = new DateTime(2020,12,2,7,00,0)
                    }
                })
            },
        });

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
