using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Models
{
    public class Seat : ISeat
    {
        public int ID { get; }
        public SeatState SeatState { get; set; }

        public Seat(int id, SeatState typeSeat)
        {
            ID = id;
            SeatState = typeSeat;
        }

        public void Click()
        {
            SeatState = (SeatState)(((int)SeatState + 1) % 2);
        }
    }
}
