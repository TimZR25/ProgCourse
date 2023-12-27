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

        public event Action<int>? OnSeatChanged;

        public CinemaHall(ICinemaHallEntity cinema)
        {
            Number = cinema.Number;
            SideSize = cinema.SideSize;
            Seats = cinema.Seats;
        }

        public CinemaHall(int hallNumber, int sideSize)
        {
            Number = hallNumber;
            SideSize = sideSize;

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    int numberSeat = i * sideSize + j + 1;
                    ISeat seat = new Seat(numberSeat, TypeSeat.Freely);

                    Seats.Add(numberSeat, seat);
                }
            }
        }

        public CinemaHall() { }

        public void SeatClick(int id)
        {
            Seats[id].Click();
            OnSeatChanged?.Invoke(id);
        }
    }
}
