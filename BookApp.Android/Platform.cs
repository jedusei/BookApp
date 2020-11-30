using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(BookApp.Droid.Platform))]
namespace BookApp.Droid
{
    class Platform : IPlatform
    {
        static Activity _mainActivity;

        public static void Init(Activity mainActivity)
        {
            _mainActivity = mainActivity;
        }

        public void SetStatusBarColor(Color color)
        {
            _mainActivity.Window.SetStatusBarColor(color.ToAndroid());
        }
    }
}