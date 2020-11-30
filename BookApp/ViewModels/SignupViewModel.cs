using BookApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;
using BookApp.Views;

namespace BookApp.ViewModels
{
    public class SignupViewModel : BaseViewModel
    {
        IUserService _userService;
        string _email;
        string _password;
        string _passwordConfirm;

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
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value, onChanged: UpdatePasswordConfirmValid);
        }
        public bool IsEmailValid { get; private set; }
        public bool IsPasswordValid { get; private set; }
        public bool IsPasswordConfirmValid { get; private set; }
        public bool IsValid { get; private set; }
        public ICommand SignupCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }

        public SignupViewModel()
        {
            _userService = DependencyService.Get<IUserService>();
            SignupCommand = new Command(SignupAsync);
            LoginCommand = new Command(async () =>
            {
                await _navigationService.GoToPageAsync<LoginPage>();
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
        void UpdatePasswordConfirmValid()
        {
            IsPasswordConfirmValid = (_password == _passwordConfirm);
            OnPropertyChanged(nameof(IsPasswordConfirmValid));
            UpdateIsValid();
        }
        void UpdateIsValid()
        {
            IsValid = IsEmailValid && IsPasswordValid && IsPasswordConfirmValid;
            OnPropertyChanged(nameof(IsValid));
        }

        async void SignupAsync()
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            try
            {
                bool success = await _userService.SignupAsync(Email, Password);
                if (!success)
                    UserDialogs.Instance.Alert("The specified email has already been registered with another account.", "Error");
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