﻿using ProgCourse.Data;
using ProgCourse.Data.FilmSession;

namespace ProgCourse.FilmSession.FilmMenu.Service
{
    public class FilmMenuService : IFilmMenuService
    {
        private IBaseRepository<IFilmSessionEntity> _repository;

        public IReadOnlyCollection<IFilmSessionEntity> FilmSessionEntities => _repository.GetAll();

        public FilmMenuService(IBaseRepository<IFilmSessionEntity> repository)
        {
            _repository = repository;
        }

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
