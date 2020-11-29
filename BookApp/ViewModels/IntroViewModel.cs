using System.Windows.Input;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class IntroViewModel : BaseViewModel
    {
        readonly int _pageCount = 3;
        int _currentPage;

        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        public ICommand NextCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }

        public IntroViewModel()
        {
            SkipCommand = new Command(() => CurrentPage = _pageCount - 1);
            NextCommand = new Command(async () =>
            {
                if (_currentPage < _pageCount - 1)
                    CurrentPage++;
                else
                    await _navigationService.GoToAsync(Routes.Get(Routes.SIGNUP), true);
            });
        }
    }
}