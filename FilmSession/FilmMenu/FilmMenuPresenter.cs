using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.LogIn.Service;

namespace ProgCourse.FilmSession.FilmMenu
{
    public class FilmMenuPresenter : IFilmMenuPresenter
    {
        private IFilmMenuView? _view;

        public ICinemaHallService CinemaHallService { get; }

        public IFilmMenuService FilmMenuService { get; }

        public ILogInService LogInService { get; }

        public FilmMenuPresenter(ICinemaHallService cinemaHallService, IFilmMenuService filmMenuService, ILogInService logInService)
        {
            CinemaHallService = cinemaHallService;
            FilmMenuService = filmMenuService;
            LogInService = logInService;
        }

        public void Init(IFilmMenuView view)
        {
            _view = view;
        }

        public bool RemoveFilmSession(int hallID, int indexView)
        {
            if (FilmMenuService.TryRemoveFilmSession(hallID) == false) return false;

            _view?.ListViewSessions.SelectedItems.Clear();
            _view?.ListViewSessions.Items[indexView].Remove();

            return true;
        }
    }
}
