using ProgCourse.CinemaHallFolder.Model;
using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.CinemaHallFolder.View;

namespace ProgCourse.CinemaHallFolder.Presenter
{
    public interface ICinemaHallPresenter
    {
        ICinemaHallService CinemaHallService { get; }
        ICinemaHall? CinemaHall { get; set; }
        void SeatClick(int id);
        void Init(ICinemaHallView view);
        bool InitCinemaHall(int cinemaNumber);
        bool BuyTickets();
    }
}
