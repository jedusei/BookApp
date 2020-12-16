using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(BookApp.iOS.Renderers.EntryRenderer))]
namespace BookApp.iOS.Renderers
{
    class EntryRenderer: Xamarin.Forms.Platform.iOS.EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.BackgroundColor = UIColor.Clear;
        }
    }
}