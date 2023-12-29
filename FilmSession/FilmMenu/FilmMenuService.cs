using ProgCourse.Data;
using ProgCourse.Data.FilmSession;

namespace ProgCourse.FilmSession.FilmMenu
{
    public class FilmMenuService : IFilmMenuService
    {
        private IBaseRepository<IFilmSessionEntity> _repository;

        public FilmMenuService(IBaseRepository<IFilmSessionEntity> repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<IFilmSessionEntity> FilmSessionEntities => _repository.GetAll();

        public bool TryRemoveFilmSession(int index)
        {
            foreach (var filmSession in FilmSessionEntities)
            {
                if (filmSession.HallID == index)
                {
                    _repository.Remove(filmSession);
                    _repository.Save();
                    return true;
                }
            }
            return false;
        }
    }
}
