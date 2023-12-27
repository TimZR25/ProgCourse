using ProgCourse.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Views
{
    public interface ICinemaHallView : IView
    {
        public Dictionary<int, Button> SeatViews { get; set; }

        public void Init(int sideSize);
        public void ChangeSeatColor(int id, Color color);
    }
}
