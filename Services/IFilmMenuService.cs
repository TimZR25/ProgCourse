using ProgCourse.Data;
using ProgCourse.Data.FilmSession;

namespace ProgCourse.Services
{
    public interface IFilmMenuService
    {
        bool TryRemoveFilmSession(int index);
        IReadOnlyCollection<IFilmSessionEntity> FilmSessionEntities { get; }
    }
}