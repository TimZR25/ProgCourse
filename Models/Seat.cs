using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Models
{
    public class Seat : ISeat
    {
        public int ID { get; }
        private SeatState _seatState;
        public SeatState SeatState
        {
            get { return _seatState; }
            set
            {
                _seatState = value;
                OnStateChanged?.Invoke(this, this);
            }
        }
        public decimal Cost { get; }

        public event EventHandler<ISeat>? OnStateChanged;

        public Seat(int id, SeatState typeSeat, decimal cost)
        {
            ID = id;
            SeatState = typeSeat;
            Cost = cost;
        }

        public void Click()
        {
            SeatState = (SeatState)(((int)SeatState + 1) % 2);
        }
    }
}
