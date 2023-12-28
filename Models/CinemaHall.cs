using ProgCourse.Data.CinemaHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgCourse.Models
{
    public class CinemaHall : ICinemaHall
    {
        public int Number { get; set; }

        public int SideSize { get; set; }

        public Dictionary<int, ISeat> Seats { get; set; } = new Dictionary<int, ISeat>();

        public List<ISeat> BookedSeats
        {
            get
            {
                List<ISeat> seats = new List<ISeat>();

                foreach (var seat in Seats)
                {
                    if (seat.Value.SeatState == SeatState.Booked) seats.Add(seat.Value);
                }

                return seats;
            }
        }
        public decimal TicketsCost
        {
            get
            {
                decimal cost = 0;

                foreach (ISeat seat in BookedSeats)
                {
                    cost += seat.Cost;
                }

                return cost;
            }
        }

        public event Action<ISeat>? OnSeatChanged;

        public CinemaHall(ICinemaHallEntity cinema)
        {
            Number = cinema.Number;
            SideSize = cinema.SideSize;
            Seats = cinema.Seats;

            foreach (var seats in Seats)
            {
                seats.Value.OnStateChanged += SeatChanged;
            }
        }

        public CinemaHall(int hallNumber, int sideSize, decimal costSeat)
        {
            Number = hallNumber;
            SideSize = sideSize;

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    int numberSeat = i * sideSize + j + 1;
                    ISeat seat = new Seat(numberSeat, SeatState.Freely, costSeat);

                    Seats.Add(numberSeat, seat);
                }
            }
        }

        public CinemaHall() { }

        public void SeatClick(int id)
        {
            if (Seats[id].SeatState == SeatState.Sold) return;

            Seats[id].Click();
        }

        public void SeatChanged(object? sender, ISeat seat)
        {
            OnSeatChanged?.Invoke(seat);
        }

        public bool BuyTickets()
        {
            if (BookedSeats.Count <= 0) return false;

            foreach (ISeat seat in BookedSeats)
            {
                seat.SeatState = SeatState.Sold;
            }

            return true;
        }

        public bool ViewClose()
        {
            if (BookedSeats.Count <= 0) return false;

            foreach (ISeat seat in BookedSeats)
            {
                seat.SeatState = SeatState.Freely;
            }

            BookedSeats.Clear();
            return true;
        }
    }
}
