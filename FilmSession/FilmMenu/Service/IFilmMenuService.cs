using ProgCourse.Data.FilmSession;

namespace ProgCourse.FilmSession.FilmMenu.Service
{
    public interface IFilmMenuService
    {
        bool TryRemoveFilmSession(int index);
        IReadOnlyCollection<IFilmSessionEntity> FilmSessionEntities { get; }
    }
}