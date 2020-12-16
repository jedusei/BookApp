using Acr.UserDialogs;
using BookApp.Services;
using BookApp.Views;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand OpenSectionCommand { get; private set; }

        public SettingsViewModel()
        {
            OpenSectionCommand = new AsyncCommand<int>(OpenSectionAsync);
        }

        async Task OpenSectionAsync(int sectionId)
        {
            await Task.Delay(300);
            switch (sectionId)
            {
                case 5:
                    bool proceed = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to log out?", "Logout");
                    if (proceed)
                    {
                        DependencyService.Get<IUserService>().Logout();
                        await _navigationService.GoToPageAsync<LoginPage>(clearHistory: true);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
