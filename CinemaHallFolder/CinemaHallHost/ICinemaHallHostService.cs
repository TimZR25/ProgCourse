namespace ProgCourse.CinemaHallFolder.CinemaHallHost
{
    public interface ICinemaHallHostService
    {
        bool ClearRepository();
        bool TryAddCinemaHall(int hallNumber, int sizeSide, decimal costSeat);
    }
}