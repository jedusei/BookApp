using BookApp.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace BookApp.Views.Base
{
    public abstract class BaseTabbedPage : Xamarin.Forms.TabbedPage, IPage
    {
        public static readonly BindableProperty TabBarPlacementBindableProperty = BindableProperty.Create(nameof(TabBarPlacement), typeof(ToolbarPlacement), typeof(BaseTabbedPage), propertyChanged: OnTabBarPlacementChanged);

        const int TRANSITION_DURATION = 250;
        const int DESTROY_DELAY = 2000;
        bool _hasLoaded;
        object _newNavigationData;
        BaseViewModel _viewModel;

        protected bool IsPaused { get; private set; }
        public BaseViewModel ViewModel
        {
            get => _viewModel;
            set => BindingContext = value;
        }
        public ToolbarPlacement TabBarPlacement
        {
            get => (ToolbarPlacement)GetValue(TabBarPlacementBindableProperty);
            set => SetValue(TabBarPlacementBindableProperty, value);
        }

        public void SetNavigationData(object navigationData)
        {
            _newNavigationData = navigationData;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            try
            {
                _viewModel = BindingContext as BaseViewModel;
            }
            catch
            {
                _viewModel = null;
            }
        }

        private static void OnTabBarPlacementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tabbedPage = bindable as Xamarin.Forms.TabbedPage;
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>()
                    .SetToolbarPlacement((ToolbarPlacement)newValue);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (IsPaused)
                return;

            if (_hasLoaded)
            {
                OnResume(_newNavigationData);
                _newNavigationData = null;
            }
            else
            {
                await App.NextTickAsync();
                _hasLoaded = true;
                IsPaused = false;
                OnStart();
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (IsPaused)
                return;

            OnPause();

            await Task.Delay(TRANSITION_DURATION);

            IsPaused = false;
            var isDetached = true;

            foreach (var p in Navigation.NavigationStack)
            {
                if (p == this)
                {
                    isDetached = false;
                    break;
                }

            }

            if (!isDetached)
            {
                await Task.Delay(DESTROY_DELAY);
                if (App.Status != AppStatus.Stopped)
                    return;
            }

            OnDestroy();
        }

        protected virtual void OnStart()
        {
            _viewModel?.OnStart();
        }
        protected virtual void OnResume(object navigationData)
        {
            _viewModel?.OnResume(navigationData);
        }
        protected virtual void OnPause()
        {
            _viewModel?.OnPause();
        }
        protected virtual void OnDestroy()
        {
            _viewModel?.OnDestroy();
        }
    }
}
