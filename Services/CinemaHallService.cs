using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Services
{
    public class CinemaHallService : ICinemaHallService
    {
        private IBaseRepository<ICinemaHallEntity> _cinemaHallRepository;

        public CinemaHallService(IBaseRepository<ICinemaHallEntity> cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public bool TryInitCinemaHall(int cinemaHallNumber, ref ICinemaHall cinemaHall)
        {
            List<ICinemaHallEntity> cinemaHalls = _cinemaHallRepository.GetAll().ToList();

            if (cinemaHallNumber > cinemaHalls.Count) throw new Exception("Попытка получить несуществующий зал");

            foreach (ICinemaHallEntity hall in cinemaHalls)
            {
                if (hall.Number == cinemaHallNumber)
                {
                    cinemaHall = new CinemaHall(hall);
                    return true;
                }
            }

            return false;
        }
    }
}
