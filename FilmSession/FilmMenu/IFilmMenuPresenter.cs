using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.LogIn.Service;

namespace ProgCourse.FilmSession.FilmMenu
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
