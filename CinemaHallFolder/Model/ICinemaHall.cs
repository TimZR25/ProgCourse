using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.Data.CinemaHall;

namespace ProgCourse.CinemaHallFolder.Model
{
    public interface ICinemaHall : ICinemaHallEntity
    {
        decimal TicketsCost { get; }
        List<ISeat> BookedSeats { get; }
        event Action<ISeat>? OnSeatChanged;
        bool TryChangeSeatState(int id);
        bool TryBuyTickets();
        bool TryClearBookedSeats();
    }
}