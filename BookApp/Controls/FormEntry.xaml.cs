using System;
using Xamarin.Forms;

namespace BookApp.Controls
{
    [System.ComponentModel.DesignTimeVisible(true)]
    public partial class FormEntry : Frame
    {
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FormEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FormEntry));
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FormEntry));
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FormEntry));
        public static BindableProperty IsPasswordVisibleProperty = BindableProperty.Create(nameof(IsPasswordVisible), typeof(bool), typeof(FormEntry), defaultBindingMode: BindingMode.OneWayToSource);
        public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(FormEntry), true);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public bool IsPasswordVisible
        {
            get => (bool)GetValue(IsPasswordVisibleProperty);
            set => SetValue(IsPasswordVisibleProperty, value);
        }
        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public FormEntry()
        {
            InitializeComponent();
        }

        void PasswordVisibilityToggle_Tapped(object sender, EventArgs e)
        {
            IsPasswordVisible = !IsPasswordVisible;
        }
    }
}