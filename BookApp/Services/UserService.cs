using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

[assembly: Dependency(typeof(BookApp.Services.UserService))]
namespace BookApp.Services
{
    class UserService : IUserService
    {
        public Task<bool> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
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
    }
}
