namespace ProgCourse.CinemaHallFolder.CinemaHallHost.Service
{
    public interface ICinemaHallHostService
    {
        bool ClearRepository();
        bool TryAddCinemaHall(int hallNumber, int sizeSide, decimal costSeat);
    }
}