using BookApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IFriendService
    {
        Task<ObservableCollection<Friend>> GetFriendsAsync();
        Task AddFriendsAsync(params Friend[] friends);
    }
}
