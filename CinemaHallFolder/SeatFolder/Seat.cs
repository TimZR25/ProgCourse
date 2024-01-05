namespace ProgCourse.CinemaHallFolder.SeatFolder
{
    public class Seat : ISeat
    {
        public int ID { get; }
        private SeatState _state;
        public SeatState State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnStateChanged?.Invoke(this, this);
            }
        }
        public decimal Cost { get; }

        public event EventHandler<ISeat>? OnStateChanged;

        public Seat(int id, SeatState typeSeat, decimal cost)
        {
            ID = id;
            State = typeSeat;
            Cost = cost;
        }

        public void ChangeState()
        {
            State = (SeatState)(((int)State + 1) % 2);
        }
    }
}
