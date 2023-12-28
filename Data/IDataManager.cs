using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.FilmSession;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    public interface IDataManager
    {
        IBaseRepository<IUserEntity> UserRepository { get; set; }

        IBaseRepository<ICinemaHallEntity> CinemaHallRepository { get; set; }
        IBaseRepository<IFilmSessionEntity> FilmSessionRepository { get; set; }

        void LoadAll();
        void SaveAll();
    }
}
