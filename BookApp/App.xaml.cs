﻿using Xamarin.Forms;
using BookApp.Services;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using System.Threading.Tasks;
using System;

namespace BookApp
{
    public enum AppStatus
    {
        Starting,
        Started,
        Paused,
        Stopped
    }

    public partial class App : Xamarin.Forms.Application
    {
        static Action _exitAction;

        public static AppStatus Status { get; private set; }
        public static event Action Exit;

        public App(Action exitAction = null)
        {
            InitializeComponent();
            _exitAction = exitAction ?? Quit;

            On<Xamarin.Forms.PlatformConfiguration.Android>()
                .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        public static Task NextTickAsync()
        {
            var tcs = new TaskCompletionSource<bool>();

            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                Device.BeginInvokeOnMainThread(() => tcs.SetResult(true));
                return false;
            });

            return tcs.Task;
        }

        public new static void Quit()
        {
            if (Status != AppStatus.Stopped && _exitAction != null)
                _exitAction.Invoke();
        }

        protected override async void OnStart()
        {
            await DependencyService.Get<INavigationService>().InitializeAsync();
            Status = AppStatus.Started;
        }

        protected override void OnSleep()
        {
            Status = AppStatus.Paused;
        }

        protected override void OnResume()
        {
            Status = AppStatus.Started;
        }

        public void OnExit()
        {
            Status = AppStatus.Stopped;
            Exit?.Invoke();
            Exit = null;
        }
    }
}
