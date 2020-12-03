using BookApp.Models;
using Xamarin.Forms;

namespace BookApp.Controls
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IncomingMessageTemplate { get; set; }
        public DataTemplate OutgoingMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return (item as Message).IsFromMe ? OutgoingMessageTemplate : IncomingMessageTemplate;
        }
    }
}
