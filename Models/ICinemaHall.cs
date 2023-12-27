using ProgCourse.Data.CinemaHall;

namespace ProgCourse.Models
{
    public interface ICinemaHall : ICinemaHallEntity
    {
        event Action<int>? OnSeatChanged;

        void SeatClick(int id);
    }
}