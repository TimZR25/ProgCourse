using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.Views;

namespace ProgCourse.CinemaHallFolder.View
{
    public interface ICinemaHallView : IView
    {
        Dictionary<int, Button> SeatViews { get; set; }

        void Init(int sideSize);
        void ChangeSeatColor(int id, SeatState seatState);
        void ChangeTicketText(int ticketAmount, decimal ticketCost);
    }
}
