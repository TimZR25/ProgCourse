using ProgCourse.CinemaHallFolder.SeatFolder;

namespace ProgCourse.Data.CinemaHall
{
    public interface ICinemaHallEntity : IEntity
    {
        int Number { get; set; }
        Dictionary<int, ISeat> Seats { get; set; }
        int SideSize { get; set; }
    }
}