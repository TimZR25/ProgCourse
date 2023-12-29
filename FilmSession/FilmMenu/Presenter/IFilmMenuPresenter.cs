using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.FilmSession.FilmMenu.Service;
using ProgCourse.FilmSession.FilmMenu.View;
using ProgCourse.LogIn.Service;

namespace ProgCourse.FilmSession.FilmMenu.Presenter
{
    public interface IFilmMenuPresenter
    {
        ICinemaHallService CinemaHallService { get; }
        IFilmMenuService FilmMenuService { get; }
        ILogInService LogInService { get; }

        void Init(IFilmMenuView view);
        bool RemoveFilmSession(int hallID, int indexView);
    }
}
