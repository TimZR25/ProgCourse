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
        private IFilmSessionHostView? _view;

        private IFilmSessionHostService _filmSessionHostService;

        public FilmSessionHostPresenter(IFilmSessionHostService filmSessionHostService)
        {
            _filmSessionHostService = filmSessionHostService;
        }

        public void Init(IFilmSessionHostView view)
        {
            _view = view;
        }

        public bool TryAddFilmSession()
        {
            if (_view is null) return false;
 
            int HallId = (int)_view.HallID.Value;

            string filmName = _view.FilmName.Text;

            TimeOnly duration = new TimeOnly(_view.Duration.Value.Hour, _view.Duration.Value.Minute);

            DateTime date = _view.Date.Value;

            return _filmSessionHostService.TryAddFilmSession(HallId, filmName, date, duration);
        }
    }
}
