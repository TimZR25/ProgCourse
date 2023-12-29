using ProgCourse.Data.CinemaHall;

namespace ProgCourse.FilmSession.FilmSessionHost
{
    public interface IFilmSessionHostService
    {
        List<ICinemaHallEntity> ReservedHalls { get; }
        bool ClearFilmSessionRepository();
        bool TryAddFilmSession(int hallID, string filmName, DateTime dateStart, TimeOnly duration);
    }
}