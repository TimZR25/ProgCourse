using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgCourse.Views
{
    public partial class CinemaHallView : Form, ICinemaHallView
    {
        public Dictionary<int, Button> SeatViews { get; set; } = new Dictionary<int, Button>();

        private IViewsProvider _viewsProvider;
        public IViewsProvider ViewsProvider => _viewsProvider;

        public event Action? OnViewClosed;

        private ICinemaHallPresenter _presenter;

        public CinemaHallView(IViewsProvider viewProvider, ICinemaHallPresenter presenter)
        {
            InitializeComponent();

            _viewsProvider = viewProvider;
            _presenter = presenter;
        }

        public void Init(int sideSize)
        {
            int buttonSize = 40;
            int offsetButton = 50;

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    int numberSeat = i * sideSize + j + 1;
                    Button seatView = new Button
                    {
                        Location = new Point(offsetButton * j + 25, offsetButton * i),
                        Size = new Size(buttonSize, buttonSize),
                        Text = $"{numberSeat}",
                        BackColor = Color.Green,
                        ForeColor = Color.White
                    };

                    seatView.Click += (_, _) => { _presenter.SeatClick(numberSeat); };

                    SeatViews.Add(numberSeat, seatView);
                    Controls.Add(seatView);
                }
            }

            Size = new Size(Size.Width + offsetButton + buttonBuy.Width, Size.Height);
        }

        public void ChangeSeatColor(int id, SeatState seatState)
        {
            Color color = Color.White;

            switch (seatState)
            {
                case SeatState.Freely:
                    color = Color.Green;
                    break;
                case SeatState.Sold:
                    color = Color.Red;
                    break;
                case SeatState.Booked:
                    color = Color.Orange;
                    break;
                default:
                    break;
            }

            SeatViews[id].BackColor = color;
        }
    }
}
