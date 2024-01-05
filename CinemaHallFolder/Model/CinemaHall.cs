using ProgCourse.CinemaHallFolder.SeatFolder;
using ProgCourse.Data.CinemaHall;

namespace ProgCourse.CinemaHallFolder.Model
{
    public class CinemaHall : ICinemaHall
    {
        public int Number { get; set; }

        public int SideSize { get; set; }

        public Dictionary<int, ISeat> Seats { get; set; } = new Dictionary<int, ISeat>();

        public List<ISeat> BookedSeats
        {
            get
            {
                List<ISeat> seats = new List<ISeat>();

                foreach (var seat in Seats)
                {
                    if (seat.Value.State == SeatState.Booked) seats.Add(seat.Value);
                }

                return seats;
            }
        }

        public decimal TicketsCost
        {
            get
            {
                decimal cost = 0;

                foreach (ISeat seat in BookedSeats)
                {
                    cost += seat.Cost;
                }

                return cost;
            }
        }

        public event Action<ISeat>? OnSeatChanged;

        public CinemaHall(ICinemaHallEntity cinema)
        {
            Number = cinema.Number;
            SideSize = cinema.SideSize;
            Seats = cinema.Seats;

            foreach (var seats in Seats)
            {
                seats.Value.OnStateChanged += SeatChanged;
            }
        }

        public CinemaHall(int hallNumber, int sideSize, decimal costSeat)
        {
            Number = hallNumber;
            SideSize = sideSize;

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    int numberSeat = i * sideSize + j + 1;
                    ISeat seat = new Seat(numberSeat, SeatState.Freely, costSeat);

                    Seats.Add(numberSeat, seat);
                }
            }
        }

        public CinemaHall() { }

        public bool TryChangeSeatState(int id)
        {
            if (Seats[id].State == SeatState.Sold) return false;

            Seats[id].ChangeState();
            return true;
        }

        public void SeatChanged(object? sender, ISeat seat)
        {
            OnSeatChanged?.Invoke(seat);
        }

        public bool TryBuyTickets()
        {
            if (BookedSeats.Count <= 0) return false;

            foreach (ISeat seat in BookedSeats)
            {
                seat.State = SeatState.Sold;
            }

            return true;
        }

        public bool TryClearBookedSeats()
        {
            if (BookedSeats.Count <= 0) return false;

            foreach (ISeat seat in BookedSeats)
            {
                seat.State = SeatState.Freely;
            }

            BookedSeats.Clear();
            return true;
        }
    }
}
