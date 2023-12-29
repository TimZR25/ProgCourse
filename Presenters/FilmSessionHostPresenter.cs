using ProgCourse.Services;
using ProgCourse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgCourse.Presenters
{
    public class FilmSessionHostPresenter : IFilmSessionHostPresenter
    {
        public IFilmSessionHostService FilmSessionHostService { get; }

        private IFilmSessionHostView? _view;

        public FilmSessionHostPresenter(IFilmSessionHostService filmSessionHostService)
        {
            FilmSessionHostService = filmSessionHostService;
        }


        public void Init(IFilmSessionHostView view)
        {
            _view = view;
        }

        public bool TryAddFilmSession()
        {
            if (_view is null) return false;
 
            int HallId = int.Parse(_view.HallID.Text);

            string filmName = _view.FilmName.Text;

            TimeOnly duration = new TimeOnly(_view.Duration.Value.Hour, _view.Duration.Value.Minute);

            DateTime date = _view.Date.Value;
            DateTime time = _view.StartTime.Value;

            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

            return FilmSessionHostService.TryAddFilmSession(HallId, filmName, dateTime, duration);
        }
    }
}
