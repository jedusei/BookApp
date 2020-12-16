using Xamarin.Forms;

namespace BookApp.Models
{
    public class IntroItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
        public Brush ImageBackground { get; set; }
        public View BackgroundView { get; set; }
    }
}
