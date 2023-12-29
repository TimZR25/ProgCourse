using ProgCourse.FilmSession.FilmSessionHost.Service;
using ProgCourse.FilmSession.FilmSessionHost.View;

namespace ProgCourse.FilmSession.FilmSessionHost.Presenter
{
    public interface IFilmSessionHostPresenter
    {
        IFilmSessionHostService FilmSessionHostService { get; }
        bool TryAddFilmSession();
        void Init(IFilmSessionHostView view);
    }
}