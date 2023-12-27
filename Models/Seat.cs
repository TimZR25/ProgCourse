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
        public TypeSeat TypeSeat { get; set; }

        public Seat(int id, TypeSeat typeSeat)
        {
            ID = id;
            TypeSeat = typeSeat;
        }

        public void Click()
        {
            TypeSeat = (TypeSeat)(((int)TypeSeat + 1) % 2);
        }
    }
}
