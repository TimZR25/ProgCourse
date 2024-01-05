namespace ProgCourse.CinemaHallFolder.SeatFolder
{
    public interface ISeat
    {
        int ID { get; }
        SeatState State { get; set; }
        decimal Cost { get; }
        event EventHandler<ISeat>? OnStateChanged;

        void ChangeState();
    }
}