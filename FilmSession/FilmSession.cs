using ProgCourse.Data.FilmSession;

namespace ProgCourse.FilmSession
{
    public class FilmSession : IFilmSessionEntity
    {
        public int HallID { get; set; }
        public string FilmName { get; set; } = "";
        public DateTime DateStart { get; set; }
        public TimeOnly Duration { get; set; }

        public FilmSession(IFilmSessionEntity filmSessionEntity)
        {
            HallID = filmSessionEntity.HallID;
            FilmName = filmSessionEntity.FilmName;
            DateStart = filmSessionEntity.DateStart;
            Duration = filmSessionEntity.Duration;
        }

        public FilmSession(int hallID, string filmName, DateTime dateStart, TimeOnly duration)
        {
            HallID = hallID;
            FilmName = filmName;
            DateStart = dateStart;
            Duration = duration;
        }

        public FilmSession() { }
    }
}
