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

            bool isExist = false;

            if (_cinemaHallRepository.GetAll().Count <= 0) return false;

            foreach (var cinemaHall in _cinemaHallRepository.GetAll())
            {
                if (cinemaHall.Number == hallID)
                {
                    isExist = true;
                    break;
                }
            }
            if (isExist == false) return false;


            foreach (var filmSession in _filmSessionRepository.GetAll())
            {
                if (filmSession.HallID == hallID) return false;
            }

            if (_filmSessionRepository.Add(new FilmSession(hallID, filmName, dateStart, duration)))
            {
                _filmSessionRepository.Save();
                return true;
            }

            return false;
        }

        public bool ClearRepository()
        {
            _filmSessionRepository.RemoveAll();
            return _filmSessionRepository.Save();
        }
    }
}
