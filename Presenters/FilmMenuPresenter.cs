using ProgCourse.Data;
using ProgCourse.Data.FilmSession;
using ProgCourse.Services;
using ProgCourse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public class FilmMenuPresenter : IFilmMenuPresenter
    {
        private IFilmMenuView? _view;

        public ICinemaHallService CinemaHallService { get; }

        public IFilmMenuService FilmMenuService { get; }

        public FilmMenuPresenter(ICinemaHallService cinemaHallService, IFilmMenuService filmMenuService)
        {
            CinemaHallService = cinemaHallService;
            FilmMenuService = filmMenuService;
        }

        public void Init(IFilmMenuView view)
        {
            _view = view;
        }

        public bool RemoveFilmSession(int index)
        {
            if (FilmMenuService.TryRemoveFilmSession(index) == false) return false;

            _view?.ListViewSessions.SelectedItems.Clear();
            _view?.ListViewSessions.Items[index].Remove();

            return true;
        }
    }
}
