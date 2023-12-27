using ProgCourse.Models;

namespace ProgCourse.Services
{
    public interface ICinemaHallService
    {
        bool TryInitCinemaHall(int cinemaHallNumber, ref ICinemaHall cinemaHall);
    }
}