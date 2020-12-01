using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            image.HeightRequest = e.ImageInformation.OriginalHeight * image.WidthRequest / e.ImageInformation.OriginalWidth;
        }
    }
}