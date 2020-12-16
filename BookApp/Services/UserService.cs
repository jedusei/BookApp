using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

[assembly: Dependency(typeof(BookApp.Services.UserService))]
namespace BookApp.Services
{
    class UserService : IUserService
    {
        const string LOGGED_IN_KEY = "logged_in";

        public bool IsLoggedIn { get; private set; }

        public UserService()
        {
            IsLoggedIn = Preferences.Get(LOGGED_IN_KEY, false);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Task.Delay(1000);
                throw new Exception();
            }

            await Task.Delay(1500);
            if (password != "1234")
                return false;

            Preferences.Set(LOGGED_IN_KEY, true);
            IsLoggedIn = true;
            return true;
        }

        public async Task<bool> SignupAsync(string email, string password)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Task.Delay(1000);
                throw new Exception();
            }

            await Task.Delay(1500);
            if (email == "test")
                return false;

            Preferences.Set(LOGGED_IN_KEY, true);
            IsLoggedIn = true;
            return true;
        }

        public void Logout()
        {
            Preferences.Clear(LOGGED_IN_KEY);
            IsLoggedIn = false;
        }
    }
}
