using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.User;
using ProgCourse.Models;
using ProgCourse.Utilities;

namespace ProgCourse.Data
{
    public class DataManager : IDataManager
    {
        public IBaseRepository<IUserEntity> UserRepository {  get; set; }
        public IBaseRepository<ICinemaHallEntity> CinemaHallRepository { get; set; }

        public DataManager(UserRepository userStorage, CinemaHallRepository cinemaHallRepository)
        {
            UserRepository = userStorage;
            CinemaHallRepository = cinemaHallRepository;
        }

        public void LoadAll()
        {
            UserRepository.Load();
            CinemaHallRepository.Load();
        }

        public void SaveAll()
        {
            UserRepository.Save();
            CinemaHallRepository.Save();
        }
    }
}
