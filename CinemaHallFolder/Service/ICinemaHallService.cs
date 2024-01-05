using ProgCourse.CinemaHallFolder.Model;

namespace ProgCourse.CinemaHallFolder.Service
{
    public interface ICinemaHallService
    {
        int CurrentIndex { get; }
        bool TryInitCinemaHall(int cinemaHallNumber, out ICinemaHall cinemaHall);
        bool TrySaveRepository();
        bool TrySetIndexHall(int index);
    }
}