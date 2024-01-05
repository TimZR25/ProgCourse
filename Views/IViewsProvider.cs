namespace ProgCourse.Views
{
    public interface IViewsProvider
    {
        IView? CurrentView { get; }

        void Register(ViewType viewType, IView view);

        void SetCurrentView(ViewType viewType);

        void Show(ViewType viewType);
    }
}
