using BookApp.Views;
using Xamarin.Forms;

namespace BookApp
{
    public static class Routes
    {
        public const string INTRO = "Intro";
        public const string SIGNUP = "Signup";
        public const string LOGIN = "Login";

        public static string Get(string routeName) => $"//{routeName}";

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute(LOGIN, typeof(LoginPage));
        }
    }
}
