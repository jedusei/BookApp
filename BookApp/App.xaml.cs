using Xamarin.Forms;
using BookApp.Services;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace BookApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            On<Xamarin.Forms.PlatformConfiguration.Android>()
                .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        protected override async void OnStart()
        {
            await DependencyService.Get<INavigationService>().InitializeAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
