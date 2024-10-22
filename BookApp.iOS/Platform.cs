﻿using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(BookApp.iOS.Platform))]
namespace BookApp.iOS
{
    class Platform : IPlatform
    {
        public void SetStatusBarColor(Color color)
        {
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                statusBar.BackgroundColor = color.ToUIColor();
        }
    }
}