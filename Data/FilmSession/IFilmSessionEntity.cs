namespace ProgCourse.Data.FilmSession
{
    public interface IFilmSessionEntity : IEntity
    {
        int HallID { get; set; }
        string FilmName { get; set; }
        DateTime DateStart { get; set; }
        TimeOnly Duration { get; set; }
    }
}
