using System.Collections.ObjectModel;

namespace BookApp.Models
{
    public class Friend
    {
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
    }
}
