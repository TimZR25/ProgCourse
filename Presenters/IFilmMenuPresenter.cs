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
    public interface IFilmMenuPresenter
    {
        ICinemaHallService CinemaHallService { get; }
        IFilmMenuService FilmMenuService { get; }

        void Init(IFilmMenuView view);
        bool RemoveFilmSession(int index);
    }
}
