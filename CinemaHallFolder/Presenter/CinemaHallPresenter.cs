using ProgCourse.CinemaHallFolder.Model;
using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.CinemaHallFolder.View;

namespace ProgCourse.CinemaHallFolder.Presenter
{
    public class CinemaHallPresenter : ICinemaHallPresenter
    {
        public ICinemaHall? CinemaHall { get; set; }

        private ICinemaHallView? _view;

        public ICinemaHallService CinemaHallService { get; }

        public CinemaHallPresenter(ICinemaHallService cinemaHallService)
        {
            CinemaHallService = cinemaHallService;
        }

        public void Init(ICinemaHallView view)
        {
            _view = view;

            _view.OnViewClosed += ViewClose;
        }

        public bool InitCinemaHall(int cinemaHallNumber)
        {
            if (CinemaHallService.TryInitCinemaHall(cinemaHallNumber, out ICinemaHall cinemaHall))
            {
                CinemaHall = cinemaHall;

                CinemaHall.OnSeatChanged += SeatStateChanged;
                _view?.Init(CinemaHall.SideSize);

                return true;
            }

            return false;
        }

        public void SeatClick(int id)
        {
            CinemaHall?.SeatClick(id);
        }

        public void SeatStateChanged(ISeat seat)
        {
            if (CinemaHall is null) return;

            _view?.ChangeSeatColor(seat.ID, seat.SeatState);
            _view?.ChangeTicketText(CinemaHall.BookedSeats.Count, CinemaHall.TicketsCost);
        }

        public bool BuyTickets()
        {
            if (CinemaHall?.BookedSeats is null) return false;

            return CinemaHall.BuyTickets();
        }

        public void ViewClose()
        {
            CinemaHall?.ViewClose();
            CinemaHallService.SaveRepository();
        }
    }
}
