using ProgCourse.CinemaHallFolder.Model;
using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;

namespace ProgCourse.CinemaHallFolder.Service
{
    public class CinemaHallService : ICinemaHallService
    {
        private IBaseRepository<ICinemaHallEntity> _cinemaHallRepository;

        private int _currentIndex;
        public int CurrentIndex => _currentIndex;

        public CinemaHallService(IBaseRepository<ICinemaHallEntity> cinemaHallRepository)
        {
            _cinemaHallRepository = cinemaHallRepository;
        }

        public bool TryInitCinemaHall(int cinemaHallNumber, out ICinemaHall cinemaHall)
        {
            cinemaHall = new CinemaHall();

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

        public bool SaveRepository()
        {
            return _cinemaHallRepository.Save();
        }

        public bool TrySetIndexHall(int index)
        {
            if (index == 0)
            {
                _currentIndex = 0;
                return false;
            }

            foreach (ICinemaHallEntity cinemaHall in _cinemaHallRepository.GetAll())
            {
                if (cinemaHall.Number == index)
                {
                    _currentIndex = index;
                    return true;
                }
            }

            return false;
        }
    }
}
