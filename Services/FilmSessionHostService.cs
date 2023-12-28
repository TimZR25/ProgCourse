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
    public class FilmSessionHostService
    {
        private IBaseRepository<IFilmSessionEntity> _repository;

        public FilmSessionHostService(IBaseRepository<IFilmSessionEntity> filmSessionRepository)
        {
            _repository = filmSessionRepository;
        }

        public bool TryAddFilmSession(int hallID, string filmName, DateTime dateStart, TimeOnly duration)
        {
            if (_repository.Add(new FilmSession(hallID, filmName, dateStart, duration)))
            {
                _repository.Save();
                return true;
            }

            return false;
        }

        public bool ClearRepository()
        {
            _repository.RemoveAll();
            return _repository.Save();
        }
    }
}
