using ProgCourse.Views;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Views
{
    public interface ICinemaHallView : IView
    {
        Dictionary<int, Button> SeatViews { get; set; }

        void Init(int sideSize);
        void ChangeSeatColor(int id, SeatState seatState);
        void ChangeTicketText(int ticketAmount, decimal ticketCost);
    }
}
