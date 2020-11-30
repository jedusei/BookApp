namespace BookApp.Views.Base
{
    public interface ITabContentView
    {
        void OnStart() { }
        void OnPause() { }
        void OnResume() { }
        void OnDestroy() { }
    }
}
