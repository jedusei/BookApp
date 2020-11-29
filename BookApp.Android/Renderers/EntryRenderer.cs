using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BookApp.Droid.Renderers.EntryRenderer))]
namespace BookApp.Droid.Renderers
{
    class EntryRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
    {
        public EntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}