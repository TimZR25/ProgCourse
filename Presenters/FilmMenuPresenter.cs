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

        public IBaseRepository<IFilmSessionEntity> FilmSessionRepository { get; }

        public FilmMenuPresenter(ICinemaHallService cinemaHallService, IBaseRepository<IFilmSessionEntity> filmSessionRepository)
        {
            CinemaHallService = cinemaHallService;
            FilmSessionRepository = filmSessionRepository;
        }

        public void Init(IFilmMenuView view)
        {
            _view = view;
        }
    }
}
