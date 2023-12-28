using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Models;
using ProgCourse.Services;
using ProgCourse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public class CinemaHallPresenter : ICinemaHallPresenter
    {
        public ICinemaHall? CinemaHall { get; set; }

        private ICinemaHallView? _view;

        private ICinemaHallService _cinemaHallService;

        public CinemaHallPresenter(ICinemaHallService cinemaHallService)
        {
            _cinemaHallService = cinemaHallService;
        }

        public void Init(ICinemaHallView view)
        {
            _view = view;

            _view.OnViewClosed += ViewClose;
        }

        public bool InitCinemaHall(int cinemaHallNumber)
        {
            
            ICinemaHall cinemaHall = new CinemaHall();

            if (_cinemaHallService.TryInitCinemaHall(cinemaHallNumber, out cinemaHall))
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
            _cinemaHallService.SaveRepository();
        }
    }
}
