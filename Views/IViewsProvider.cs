using ProgCourse.Views;

namespace ProgCourse.Forms
{
    public interface IViewsProvider
    {
        IView? CurrentView { get; }

        void Register(ViewType viewType, IView view);

        void Show(ViewType viewType);
    }
}
