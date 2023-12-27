using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Models;
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

        public void Test(ICinemaHallEntity cinemaHall)
        {
            CinemaHall = new CinemaHall(cinemaHall);

            CinemaHall.OnSeatChanged += SeatChanged;

            _view?.Init(CinemaHall.SideSize);
        }

        public void InitCinemaHall(int cinemaHallNumber)
        {
            List<ICinemaHallEntity> cinemaHalls = _dataManager.CinemaHallRepository.GetAll().ToList();

            if (cinemaHallNumber > cinemaHalls.Count) throw new Exception("Попытка получить несуществующий зал");

            foreach (ICinemaHallEntity cinemaHall in cinemaHalls)
            {
                if (cinemaHall.Number == cinemaHallNumber)
                {
                    CinemaHall = new CinemaHall(cinemaHall);

                    CinemaHall.OnSeatChanged += SeatChanged;

                    _view?.Init(CinemaHall.SideSize);

                    return;
                }
            }
        }

        public void SeatClick(int id)
        {
            CinemaHall?.SeatClick(id);
        }

        public void SeatChanged(int id)
        {
            Color color = Color.White;

            switch (CinemaHall?.Seats[id].TypeSeat)
            {
                case TypeSeat.Freely:
                    color = Color.Green;
                    break;
                case TypeSeat.Sold:
                    color = Color.Red;
                    break;
                case TypeSeat.Booked:
                    color = Color.Orange;
                    break;
                default:
                    break;
            }

            _view?.ChangeSeatColor(id, color);
        }
    }
}
