using ProgCourse.Data.CinemaHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data.FilmSession
{
    public abstract class FilmSessionRepository : IBaseRepository<IFilmSessionEntity>
    {
        protected List<IFilmSessionEntity> _filmSessions = new();

        public bool Add(IFilmSessionEntity filmSession)
        {
            if (filmSession == null || Contains(filmSession)) return false;

            _filmSessions.Add(filmSession);

            return true;
        }

        public bool Remove(IFilmSessionEntity filmSession)
        {
            if (!_filmSessions.Contains(filmSession)) return false;

            _filmSessions.Remove(filmSession);

            return true;
        }

        public bool RemoveAll()
        {
            if (_filmSessions.Count <= 0) return false;

            _filmSessions.Clear();

            return true;
        }

        public IReadOnlyCollection<IFilmSessionEntity> GetAll()
        {
            return _filmSessions.AsReadOnly();
        }

        public bool Contains(IFilmSessionEntity filmSession)
        {
            if (_filmSessions.Count <= 0) return false;

            foreach (IFilmSessionEntity cinemaHall in _filmSessions)
            {
                if (filmSession.HallID == cinemaHall.HallID) return true;
            }

            return false;
        }

        public abstract bool Load();
        public abstract bool Save();
    }
}
