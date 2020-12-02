﻿using BookApp.Models;
using BookApp.Services;
using System.Collections.ObjectModel;
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
        public ICommand AddFriendCommand { get; private set; }
        public ICommand OpenChatCommand { get; private set; }

        public FriendListViewModel()
        {
            _friendService = DependencyService.Get<IFriendService>();
        }

        public override async void OnStart()
        {
            base.OnStart();
            LoadStatus = LoadStatus.Loading;

            Friends = await _friendService.GetFriendsAsync();
            OnPropertyChanged(nameof(Friends));

            LoadStatus = LoadStatus.Loaded;
        }
    }
}