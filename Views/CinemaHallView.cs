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
            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    int numberSeat = i * sideSize + j + 1;
                    Button seatView = new Button
                    {
                        Location = new Point(50 * j + 25, 50 * i),
                        Size = new Size(40, 40),
                        Text = $"{numberSeat}",
                        BackColor = Color.Green,
                        ForeColor = Color.White
                    };

                    seatView.Click += (_, _) => { _presenter.SeatClick(numberSeat); };

                    SeatViews.Add(numberSeat, seatView);
                    Controls.Add(seatView);
                }
            }
        }

        void IView.ShowDialog()
        {
            ShowDialog();
        }

        public void ChangeSeatColor(int id, Color color)
        {
            SeatViews[id].BackColor = color;
        }
    }
}
