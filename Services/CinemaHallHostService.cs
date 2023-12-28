using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Services
{
    public class CinemaHallHostService : ICinemaHallHostService
    {
        private IBaseRepository<ICinemaHallEntity> _repository;

        public CinemaHallHostService(IBaseRepository<ICinemaHallEntity> cinemaHallRepository)
        {
            _repository = cinemaHallRepository;
        }

        public bool TryAddCinemaHall(int hallNumber, int sizeSide, decimal costSeat)
        {
            if (hallNumber <= 0) return false;
            if (sizeSide <= 0) return false;
            if (costSeat <= 0) return false;

            if (_repository.Add(new CinemaHall(hallNumber, sizeSide, costSeat)))
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
