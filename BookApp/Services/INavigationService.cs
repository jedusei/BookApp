using BookApp.Views;
using BookApp.Views.Base;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface INavigationService
    {
        Task InitializeAsync( )=>Task.CompletedTask;
        Task GoToPageAsync<TPage>(object navigationData = null, bool clearHistory = false) where TPage : BasePage;
        Task GoBackAsync(bool animated = true);
    }
}
