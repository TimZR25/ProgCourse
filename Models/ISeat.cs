namespace ProgCourse.Models
{
    public interface ISeat
    {
        int ID { get; }
        TypeSeat TypeSeat { get; set; }

        void Click();
    }
}