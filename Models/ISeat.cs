namespace ProgCourse.Models
{
    public interface ISeat
    {
        int ID { get; }
        SeatState SeatState { get; set; }

        void Click();
    }
}