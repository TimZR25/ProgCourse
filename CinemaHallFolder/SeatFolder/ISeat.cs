namespace ProgCourse.CinemaHallFolder.SeatFolder
{
    public interface ISeat
    {
        int ID { get; }
        SeatState SeatState { get; set; }
        decimal Cost { get; }
        event EventHandler<ISeat>? OnStateChanged;

        void Click();
    }
}