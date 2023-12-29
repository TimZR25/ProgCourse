using ProgCourse.Services;
using ProgCourse.Views;

namespace ProgCourse.Presenters
{
    public interface IFilmSessionHostPresenter
    {
        IFilmSessionHostService FilmSessionHostService { get; }
        bool TryAddFilmSession();
        void Init(IFilmSessionHostView view);
    }
}