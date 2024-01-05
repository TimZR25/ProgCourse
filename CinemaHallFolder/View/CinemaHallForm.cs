using ProgCourse.CinemaHallFolder.Presenter;
using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.CinemaHallFolder.View;

namespace ProgCourse.Views
{
    public partial class CinemaHallForm : Form, ICinemaHallView
    {
        public Dictionary<int, Button> SeatViews { get; set; } = new Dictionary<int, Button>();

        private IViewsProvider _viewsProvider;
        public IViewsProvider ViewsProvider => _viewsProvider;

        public event Action? OnViewClosed;

        private ICinemaHallPresenter _presenter;

        private int _buttonSize = 40;
        private int _offsetButton = 5;

        private List<Control> _controls = new List<Control>();

        public CinemaHallForm(IViewsProvider viewProvider, ICinemaHallPresenter presenter)
        {
            InitializeComponent();

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            _viewsProvider = viewProvider;
            _presenter = presenter;
        }

        public void Init(int sideSize)
        {
            foreach (var item in _controls)
            {
                Controls.Remove(item);
            }
            _controls = new List<Control>();
            SeatViews = new Dictionary<int, Button>();


            Label labelCinema = new Label()
            {
                Text = "ЭКРАН",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(_buttonSize / 2 + _offsetButton, 0),
                Size = new Size(_buttonSize * sideSize + _offsetButton * (sideSize - 1), 30),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.Black
            };

            Controls.Add(labelCinema);
            _controls.Add(labelCinema);

            for (int y = 0; y < sideSize; y++)
            {
                Label labelRow = new Label()
                {
                    Location = new Point(0, labelCinema.Height + (_buttonSize + _offsetButton) * y + _buttonSize / 2),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(_buttonSize / 2, _buttonSize / 2),
                    Text = $"{y + 1}",
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                Controls.Add(labelRow);
                _controls.Add(labelRow);

                for (int x = 0; x < sideSize; x++)
                {
                    int numberSeat = y * sideSize + x + 1;

                    Button seatView = new Button
                    {
                        Location = new Point(labelRow.Width + _offsetButton + (_buttonSize + _offsetButton) * x
                        , 2 * labelRow.Size.Height + (_buttonSize + _offsetButton) * y),
                        Size = new Size(_buttonSize, _buttonSize),
                        Text = $"{x + 1}",
                        ForeColor = Color.White
                    };

                    seatView.Click += (_, _) => { _presenter.TryChangeSeatState(numberSeat); };

                    SeatViews.Add(numberSeat, seatView);

                    if (_presenter.CinemaHall != null) ChangeSeatColor(numberSeat, _presenter.CinemaHall.Seats[numberSeat].State);

                    Controls.Add(seatView);
                    _controls.Add(seatView);
                }
            }

            Text = "Зал №" + _presenter?.CinemaHall?.Number.ToString();

            Size = new Size(labelCinema.Width + labelCinema.Height + (_buttonSize + _offsetButton) + buttonBuy.Width,
                (_buttonSize + _offsetButton) * (sideSize + 1) + labelCinema.Height);
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
            _presenter.TryBuyTickets();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnLoad(e);

            _presenter.TryInitCinemaHall(_presenter.CinemaHallService.CurrentIndex);
        }
    }
}
