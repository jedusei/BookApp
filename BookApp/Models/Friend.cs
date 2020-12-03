using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BookApp.Models
{
    public class Friend : BindableObject
    {
        ObservableCollection<Message> _messages;

        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set
            {
                if (_messages != value)
                {
                    if (_messages != null)
                        _messages.CollectionChanged -= OnMessageListChanged;
                    if (value != null)
                        value.CollectionChanged += OnMessageListChanged;

                    _messages = value;
                    OnPropertyChanged(nameof(Messages));
                }
            }
        }
        public Message LastMessage => (Messages?.Count > 0) ? Messages[^1] : null;

        void OnMessageListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LastMessage));
        }
    }
}
