using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewSubpage2 : ContentView
    {
        public AddReviewSubpage2()
        {
            InitializeComponent();
        }

        private void CachedImage_Success(object sender, FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                image.HeightRequest = e.ImageInformation.OriginalHeight * image.WidthRequest / e.ImageInformation.OriginalWidth;
            });
        }
    }
}