using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IUserService
    {
        Task<bool> SignupAsync(string email, string password);
        Task<bool> LoginAsync(string email, string password);
        void Logout();
    }
}
