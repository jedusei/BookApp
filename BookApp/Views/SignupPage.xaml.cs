using BookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            BindingContext = new SignupViewModel();
        }
    }
}