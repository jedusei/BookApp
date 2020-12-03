using BookApp.Models;
using BookApp.Views;
using BookApp.Views.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BookApp.Services.NavigationService))]
namespace BookApp.Services
{
    class NavigationService : INavigationService
    {
        public async Task InitializeAsync()
        {
            await GoToPageAsync<ChatPage>(new ChatPage.Args
            {
                Friend = new Friend
                {
                    Name = "Rachel",
                    ProfileImageUrl = "https://dieteticallyspeaking.com/wp-content/uploads/2017/01/profile-square.jpg",
                    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>(new Message[]
                    {
                        new Message
                        {
                            IsFromMe = true,
                            Content = "Quisque dictum varius arcu.",
                            DateCreated = new DateTime(2020,12,2,13,30,0)
                        },
                        new Message
                        {
                            IsFromMe = false,
                            Content = "Yeah, I think so too. I also loved his other books.",
                            DateCreated = new DateTime(2020,12,2,13,31,0)
                        },
                        new Message
                        {
                            IsFromMe = true,
                            Content = "Haha, yes!",
                            DateCreated = new DateTime(2020,12,2,13,31,10)
                        },
                        new Message
                        {
                            IsFromMe = false,
                            Content = "LOL <3 Agree.",
                            DateCreated = new DateTime(2020,12,2,13,33,0)
                        },
                        new Message
                        {
                            IsFromMe = true,
                            Content = "Quisque dictum varius arcu.",
                            DateCreated = new DateTime(2020,12,2,13,35,0)
                        },
                        new Message
                        {
                            IsFromMe = false,
                            Content = "Yeah, I think so too. I also loved his other books.",
                            DateCreated = new DateTime(2020,12,2,13,36,0)
                        },
                        new Message
                        {
                            IsFromMe = true,
                            Content = "Haha, yes!",
                            DateCreated = new DateTime(2020,12,2,13,36,10)
                        },
                        new Message
                        {
                            IsFromMe = false,
                            Content = "LOL <3 Agree.",
                            DateCreated = new DateTime(2020,12,2,13,40,0)
                        }
                    })
                }
            });
        }

        public async Task GoToPageAsync<TPage>(object navigationData = null, bool clearHistory = false, bool removeCurrentPage = false) where TPage : BasePage
        {
            BasePage targetPage = null;
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
                            targetPage = page as BasePage;
                            break;
                        }
                    }

                    if (targetPage == navigation.NavigationStack[^1])
                    {
                        targetPage.SetNavigationData(navigationData);
                        return;
                    }
                }

                if (targetPage == null)
                    targetPage = await CreatePageAsync(pageType, navigationData);
                else
                {
                    navigation.RemovePage(targetPage);
                    targetPage.SetNavigationData(navigationData);
                }

                await navigation.PushAsync(targetPage);

                if (!clearHistory)
                {
                    if (removeCurrentPage)
                        navigation.RemovePage(navigation.NavigationStack[^2]);
                }
                else
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

        async Task<BasePage> CreatePageAsync(Type pageType, object navigationData)
        {
            var page = Activator.CreateInstance(pageType) as BasePage;
            if (page.ViewModel != null)
                await page.ViewModel.InitializeAsync(navigationData);

            return page;
        }

    }
}
