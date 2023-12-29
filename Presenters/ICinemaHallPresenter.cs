using ProgCourse.Models;
using ProgCourse.Services;
using ProgCourse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
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
