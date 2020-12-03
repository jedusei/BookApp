using BookApp.Views.Base;
using BookApp.ViewModels;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class ReviewThanksPage : BasePage
    {
        public ReviewThanksPage()
        {
            InitializeComponent();
            BindingContext = new ReviewThanksViewModel();
        }

        void CachedImage_Success(object sender, FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var image = sender as View;
                image.WidthRequest = e.ImageInformation.OriginalWidth * image.HeightRequest / e.ImageInformation.OriginalHeight;
            });
        }
    }
}