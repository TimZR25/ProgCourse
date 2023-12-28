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
using System.Xml;

namespace ProgCourse.Views
{
    public partial class CinemaHallView : Form, ICinemaHallView
    {
        public Dictionary<int, Button> SeatViews { get; set; } = new Dictionary<int, Button>();

        private IViewsProvider _viewsProvider;
        public IViewsProvider ViewsProvider => _viewsProvider;

        public event Action? OnViewClosed;

        private ICinemaHallPresenter _presenter;

        private int buttonSize = 40;
        private int offsetButton = 45;

        public CinemaHallView(IViewsProvider viewProvider, ICinemaHallPresenter presenter)
        {
            InitializeComponent();

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            _viewsProvider = viewProvider;
            _presenter = presenter;
        }

        public void Init(int sideSize)
        {
            Label labelCinema = new Label()
            {
                Text = "ЭКРАН",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(buttonSize / 2, 0),
                Size = new Size(offsetButton * sideSize, 30),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.Black
            };

            for (int y = 0; y < sideSize; y++)
            {
                Label labelRow = new Label()
                {
                    Location = new Point(0, labelCinema.Height + offsetButton * y + offsetButton / 2),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(buttonSize / 2, buttonSize / 2),
                    Text = $"{y + 1}",
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                Controls.Add(labelRow);

                for (int x = 0; x < sideSize; x++)
                {
                    int numberSeat = y * sideSize + x + 1;

                    Button seatView = new Button
                    {
                        Location = new Point(labelRow.Location.X + offsetButton * x + offsetButton / 2, 2 * labelRow.Size.Height + offsetButton * y),
                        Size = new Size(buttonSize, buttonSize),
                        Text = $"{x + 1}",
                        ForeColor = Color.White
                    };

                    seatView.Click += (_, _) => { _presenter.SeatClick(numberSeat); };

                    SeatViews.Add(numberSeat, seatView);

                    if (_presenter.CinemaHall != null) ChangeSeatColor(numberSeat, _presenter.CinemaHall.Seats[numberSeat].SeatState);

                    Controls.Add(seatView);
                }
            }


            Controls.Add(labelCinema);

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

        public void ChangeTicketText(int ticketAmount, decimal ticketCost)
        {
            labelAmount.Text = ticketAmount.ToString();
            labelCost.Text = ticketCost.ToString();
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            _presenter.BuyTickets();
        }
    }
}
