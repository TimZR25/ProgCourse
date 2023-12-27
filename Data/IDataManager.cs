using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    public interface IDataManager
    {
        IBaseRepository<IUserEntity> UserRepository { get; set; }
        IUserEntity? CurrentUser { get; set; }

        IBaseRepository<ICinemaHallEntity> CinemaHallRepository { get; set; }

        void LoadAll();
        void SaveAll();

        bool TrySignUpUser(string login, string password, out string errorText);
        bool TryLogInUser(string login, string password, out string errorText);
    }
}
