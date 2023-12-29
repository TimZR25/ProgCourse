using ProgCourse.Views;

namespace ProgCourse.Presenters
{
    public interface IFilmSessionHostPresenter
    {
        bool TryAddFilmSession();
        void Init(IFilmSessionHostView view);
    }
}