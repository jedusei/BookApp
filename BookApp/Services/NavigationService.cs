using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.NavigationService))]
namespace BookApp.Services
{
    class NavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
            //await GoToAsync(Routes.INTRO);
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public Task GoToAsync(string route, bool clearHistory = false)
        {
            return Shell.Current.GoToAsync(route);
        }
    }
}
