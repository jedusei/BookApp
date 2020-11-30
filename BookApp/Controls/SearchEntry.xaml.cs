using System;
using Xamarin.Forms;

namespace BookApp.Controls
{
    [System.ComponentModel.DesignTimeVisible(true)]
    public partial class SearchEntry : Frame
    {
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FormEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FormEntry));
        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(FormEntry));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public SearchEntry()
        {
            InitializeComponent();
        } 
    }
}