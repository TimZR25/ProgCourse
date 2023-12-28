using ProgCourse.Models;

namespace ProgCourse.Services
{
    public interface ICinemaHallService
    {
        int CurrentIndex { get; }
        bool TryInitCinemaHall(int cinemaHallNumber, out ICinemaHall cinemaHall);
        public bool SaveRepository();
        public bool TrySetIndexHall(int index);
    }
}