using BookApp.Views;
using BookApp.Views.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.NavigationService))]
namespace BookApp.Services
{
    class NavigationService : INavigationService
    {
        public async Task InitializeAsync()
        {
            await GoToPageAsync<MainPage>();
        }

        public async Task GoToPageAsync<TPage>(object navigationData = null, bool clearHistory = false) where TPage : IPage
        {
            Page targetPage = null;
            if (Application.Current.MainPage == null)
            {
                targetPage = await CreatePageAsync(typeof(TPage), navigationData);
                Application.Current.MainPage = new NavigationPage(targetPage);
            }
            else
            {
                var navigation = Application.Current.MainPage.Navigation;
                var pageType = typeof(TPage);
                bool isSingleton = pageType.GetCustomAttributes(typeof(SingletonPageAttribute), false).Length > 0;
                if (isSingleton)
                {
                    int i = 0;
                    for (; i < navigation.NavigationStack.Count; i++)
                    {
                        var page = navigation.NavigationStack[i];
                        if (page.GetType() == pageType)
                        {
                            targetPage = page;
                            break;
                        }
                    }

                    if (targetPage == navigation.NavigationStack[^1])
                    {
                        (targetPage as IPage).SetNavigationData(navigationData);
                        return;
                    }
                }

                if (targetPage == null)
                    targetPage = await CreatePageAsync(pageType, navigationData);
                else
                {
                    navigation.RemovePage(targetPage);
                    (targetPage as IPage).SetNavigationData(navigationData);
                }

                await navigation.PushAsync(targetPage);

                if (clearHistory)
                {
                    for (int j = navigation.NavigationStack.Count - 2; j >= 0; j--)
                        navigation.RemovePage(navigation.NavigationStack[j]);
                }
            }
        }

        public async Task GoBackAsync(bool animated)
        {
            if (Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
                await Application.Current.MainPage.Navigation.PopAsync(animated);
            else
                App.Quit();
        }

        async Task<Page> CreatePageAsync(Type pageType, object navigationData)
        {
            var page = Activator.CreateInstance(pageType) as Page;
            await (page as IPage).ViewModel?.InitializeAsync(navigationData);
            return page;
        }

    }
}
