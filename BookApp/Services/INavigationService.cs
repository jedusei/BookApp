using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task GoToAsync(string route, bool clearHistory = false);
        Task GoBackAsync();
    }
}
