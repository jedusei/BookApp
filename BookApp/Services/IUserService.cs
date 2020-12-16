using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IUserService
    {
        bool IsLoggedIn { get; }
        Task<bool> SignupAsync(string email, string password);
        Task<bool> LoginAsync(string email, string password);
        void Logout();
    }
}
