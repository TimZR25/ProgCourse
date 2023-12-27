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
    public class CinemaHallHostService
    {
        private IBaseRepository<ICinemaHallEntity> repository;

        public CinemaHallHostService(IBaseRepository<ICinemaHallEntity> cinemaHallRepository)
        {
            repository = cinemaHallRepository;
        }

        public bool TryAddCinemaHall(int hallNumber, int sizeSide)
        {
            if (repository.Add(new CinemaHall(hallNumber, sizeSide)))
            {
                repository.Save();
                return true;
            }

            return false;
        }
    }
}
