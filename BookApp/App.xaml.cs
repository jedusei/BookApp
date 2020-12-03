using Xamarin.Forms;
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
        public static readonly BindableProperty StatusBarColorProperty = BindableProperty.CreateAttached("StatusBarColor", typeof(Color), typeof(App), Color.White, propertyChanged: OnStatusBarColorChanged);

        public static AppStatus Status { get; private set; }
        public static new IPlatform Platform { get; private set; }
        public static event Action Exit;

        public Color StatusBarColor
        {
            get => (Color)GetValue(StatusBarColorProperty);
            set => SetValue(StatusBarColorProperty, value);
        }

        public App(Action exitAction = null)
        {
            InitializeComponent();
            _exitAction = exitAction ?? Quit;

            if (!DesignMode.IsDesignModeEnabled)
                Platform = DependencyService.Get<IPlatform>();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU5ODk4QDMxMzgyZTMzMmUzMG9BL2xkNGVFZlZjWmo4Y0RFQ0FFMmUxN0ozVlBzQ282blRQZWJGdWdHS2s9");

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

        static void OnStatusBarColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Platform.SetStatusBarColor((Color)newValue);
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
