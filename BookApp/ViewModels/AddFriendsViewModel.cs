using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class AddFriendsViewModel : BaseViewModel
    {
        IFriendService _friendService;
        Friend[] _friends = new Friend[] {
            new Friend
            {
                Name = "Rachel",
                ProfileImageUrl = "https://dieteticallyspeaking.com/wp-content/uploads/2017/01/profile-square.jpg",
                Messages = new ObservableCollection<Message>(new Message[]
                {
                    new Message
                    {
                        IsFromMe = true,
                        Content = "Quisque dictum varius arcu.",
                        DateCreated = new DateTime(2020,12,2,13,30,0)
                    },
                    new Message
                    {
                        IsFromMe = false,
                        Content = "Yeah, I think so too. I also loved his other books.",
                        DateCreated = new DateTime(2020,12,2,13,31,0)
                    },
                    new Message
                    {
                        IsFromMe = true,
                        Content = "Haha, yes!",
                        DateCreated = new DateTime(2020,12,2,13,31,10)
                    },
                    new Message
                    {
                        IsFromMe = false,
                        Content = "LOL <3 Agree.",
                        DateCreated = new DateTime(2020,12,2,13,33,0)
                    },
                    new Message
                    {
                        IsFromMe = true,
                        Content = "Quisque dictum varius arcu.",
                        DateCreated = new DateTime(2020,12,2,13,35,0)
                    },
                    new Message
                    {
                        IsFromMe = false,
                        Content = "Yeah, I think so too. I also loved his other books.",
                        DateCreated = new DateTime(2020,12,2,13,36,0)
                    },
                    new Message
                    {
                        IsFromMe = true,
                        Content = "Haha, yes!",
                        DateCreated = new DateTime(2020,12,2,13,36,10)
                    },
                    new Message
                    {
                        IsFromMe = false,
                        Content = "LOL <3 Agree.",
                        DateCreated = new DateTime(2020,12,2,13,40,0)
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
        };

        public ICommand AddFriendsCommand { get; private set; }

        public AddFriendsViewModel()
        {
            _friendService = DependencyService.Get<IFriendService>();
            AddFriendsCommand = new Xamarin.Forms.Command(AddFriends);
        }

        async void AddFriends()
        {
            await Task.Delay(300);
            await _navigationService.GoToPageAsync<ImportingContactsPage>(removeCurrentPage: true);
            var friends = await _friendService.GetFriendsAsync();
            if (friends.Count == 0)
                await _friendService.AddFriendsAsync(_friends);

            await Task.Delay(2000);
            await _navigationService.GoBackAsync();
        }
    }
}
