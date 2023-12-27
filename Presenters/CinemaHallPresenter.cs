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

        private IDataManager _dataManager;

        public CinemaHallPresenter(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Init(ICinemaHallView view)
        {
            _view = view;
        }

        public bool InitCinemaHall(int cinemaHallNumber)
        {
            CinemaHallService cineService = new CinemaHallService(_dataManager.CinemaHallRepository);
            ICinemaHall cinemaHall = new CinemaHall();

            if (cineService.TryInitCinemaHall(cinemaHallNumber, ref cinemaHall))
            {
                CinemaHall = cinemaHall;

                CinemaHall.OnSeatChanged += SeatChanged;
                _view?.Init(CinemaHall.SideSize);

                return true;
            }

            return false;
        }

        public void SeatClick(int id)
        {
            CinemaHall?.SeatClick(id);
        }

        public void SeatChanged(int id)
        {
            if (CinemaHall is null) return;

            SeatState seatState = CinemaHall.Seats[id].SeatState;

            _view?.ChangeSeatColor(id, seatState);
        }
    }
}
