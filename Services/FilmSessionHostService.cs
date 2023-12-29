using ProgCourse.Data.CinemaHall;
using ProgCourse.Data;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data.FilmSession;

namespace ProgCourse.Services
{
    public class FilmSessionHostService : IFilmSessionHostService
    {
        private IBaseRepository<IFilmSessionEntity> _filmSessionRepository;
        private IBaseRepository<ICinemaHallEntity> _cinemaHallRepository;

        public List<ICinemaHallEntity> ReservedHalls
        {
            get
            {
                List<ICinemaHallEntity> ids = new List<ICinemaHallEntity>();
                foreach (var item in _cinemaHallRepository.GetAll())
                {
                    if (IsReservedSession(item.Number)) continue;

                    ids.Add(item);

                }

                return ids;
            }
        }

        public FilmSessionHostService(IBaseRepository<IFilmSessionEntity> filmSessionRepository, IBaseRepository<ICinemaHallEntity> cinemaHallRepository)
        {
            _filmSessionRepository = filmSessionRepository;
            _cinemaHallRepository = cinemaHallRepository;
        }

        public bool TryAddFilmSession(int hallID, string filmName, DateTime dateStart, TimeOnly duration)
        {
            if (hallID <= 0) return false;
            if (filmName == string.Empty) return false;
            if (duration.Hour + duration.Minute <= 0) return false;

            
            if (IsExistHall(hallID) == false) return false;

            if (IsReservedSession(hallID)) return false;

            if (_filmSessionRepository.Add(new FilmSession(hallID, filmName, dateStart, duration)))
            {
                _filmSessionRepository.Save();
                return true;
            }

            return false;
        }

        private bool IsExistHall(int hallId)
        {
            if (_cinemaHallRepository.GetAll().Count <= 0) throw new Exception("Ноль кино-залов");

            foreach (var cinemaHall in _cinemaHallRepository.GetAll())
            {
                if (cinemaHall.Number == hallId)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsReservedSession(int id)
        {
            foreach (var filmSession in _filmSessionRepository.GetAll())
            {
                if (filmSession.HallID == id) return true;
            }

            return false;
        }

        public bool ClearFilmSessionRepository()
        {
            _filmSessionRepository.RemoveAll();
            return _filmSessionRepository.Save();
        }
    }
}
