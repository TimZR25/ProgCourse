using ProgCourse.Models;

namespace ProgCourse.Services
{
    public interface ICinemaHallService
    {
        bool TryInitCinemaHall(int cinemaHallNumber, out ICinemaHall cinemaHall);
        public bool SaveRepository();
    }
}