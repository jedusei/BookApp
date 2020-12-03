using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

[assembly: Dependency(typeof(BookApp.Services.UserService))]
namespace BookApp.Services
{
    class UserService : IUserService
    {
        public async Task<bool> LoginAsync(string email, string password)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Task.Delay(1000);
                throw new Exception();
            }

            await Task.Delay(1500);
            return password == "1234";
        }

        public async Task<bool> SignupAsync(string email, string password)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Task.Delay(1000);
                throw new Exception();
            }

            await Task.Delay(1500);
            return email != "test"; // Assume test is already a registered user
        }

        public void Logout()
        {

        }
    }
}
