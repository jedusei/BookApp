using BookApp.ViewModels;

namespace BookApp.Views.Base
{
    public interface IPage
    {
        BaseViewModel ViewModel { get; set; }
        void SetNavigationData(object data);
    }
}
