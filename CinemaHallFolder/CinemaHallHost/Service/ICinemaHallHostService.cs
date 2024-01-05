namespace ProgCourse.CinemaHallFolder.CinemaHallHost.Service
{
    public interface ICinemaHallHostService
    {
        bool TryClearRepository();
        bool TryAddCinemaHall(int hallNumber, int sizeSide, decimal costSeat);
    }
}