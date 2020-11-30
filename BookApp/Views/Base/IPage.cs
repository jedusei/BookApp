using BookApp.ViewModels;
using System;

namespace BookApp.Views.Base
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SingletonPageAttribute : Attribute
    {
    }

    public interface IPage
    {
        BaseViewModel ViewModel { get; set; }
        void SetNavigationData(object data);
    }
}
