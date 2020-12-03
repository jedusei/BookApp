using Acr.UserDialogs;
using BookApp.Services;
using BookApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        IUserService _userService;
        string _email;
        string _password;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, onChanged: UpdateEmailValid);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, onChanged: UpdatePasswordValid);
        }
        public bool IsEmailValid { get; private set; }
        public bool IsPasswordValid { get; private set; }
        public bool IsValid { get; private set; }
        public ICommand SignupCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            _userService = DependencyService.Get<IUserService>();

            LoginCommand = new Command(LoginAsync);
            SignupCommand = new Command(async () =>
            {
                await _navigationService.GoToPageAsync<SignupPage>(removeCurrentPage: true);
            });
        }

        void UpdateEmailValid()
        {
            IsEmailValid = !string.IsNullOrWhiteSpace(_email);
            OnPropertyChanged(nameof(IsEmailValid));
            UpdateIsValid();
        }
        void UpdatePasswordValid()
        {
            IsPasswordValid = !string.IsNullOrWhiteSpace(_password);
            OnPropertyChanged(nameof(IsPasswordValid));
            UpdateIsValid();
        }
        void UpdateIsValid()
        {
            IsValid = IsEmailValid && IsPasswordValid;
            OnPropertyChanged(nameof(IsValid));
        }

        async void LoginAsync()
        {
            UserDialogs.Instance.ShowLoading("Logging in...");
            try
            {
                bool success = await _userService.LoginAsync(Email, Password);
                if (success)
                    await _navigationService.GoToPageAsync<MainPage>(clearHistory: true);
                else
                    UserDialogs.Instance.Alert("The given email or password is invalid.", "Error");
            }
            catch
            {
                UserDialogs.Instance.Alert("Please make sure you're connected to the internet and try again.", "Error");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
