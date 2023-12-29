using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.Data.CinemaHall;

namespace ProgCourse.CinemaHallFolder.Model
{
    public interface ICinemaHall : ICinemaHallEntity
    {
        decimal TicketsCost { get; }
        event Action<ISeat>? OnSeatChanged;
        List<ISeat> BookedSeats { get; }
        void SeatClick(int id);
        bool BuyTickets();
        bool ViewClose();
    }
}