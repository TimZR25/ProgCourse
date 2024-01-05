using ProgCourse.CinemaHallFolder.Model;
using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.CinemaHallFolder.View;

namespace ProgCourse.CinemaHallFolder.Presenter
{
    public interface ICinemaHallPresenter
    {
        ICinemaHallService CinemaHallService { get; }
        ICinemaHall? CinemaHall { get; set; }
        bool TryChangeSeatState(int id);
        void Init(ICinemaHallView view);
        bool TryInitCinemaHall(int cinemaNumber);
        bool TryBuyTickets();
    }
}
