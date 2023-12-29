using ProgCourse.Data.FilmSession;

namespace ProgCourse.FilmSession.FilmMenu
{
    public interface IFilmMenuService
    {
        bool TryRemoveFilmSession(int index);
        IReadOnlyCollection<IFilmSessionEntity> FilmSessionEntities { get; }
    }
}