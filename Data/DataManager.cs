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
        private IUserEntity? _currentUser = null;

        public IUserEntity? CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

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

        public bool TrySignUpUser(string login, string password, out string errorText)
        {
            errorText = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                errorText = "Пустое значение логина или пароля";
                return false;
            }

            password = HashConverter.ToHashString(password);

            var user = (from x in UserRepository.GetAll()
                        where x.Login == login && x.Password == password
                        select x).FirstOrDefault();

            if (user != null)
            {
                errorText = "Такой пользователь уже существует";
                return false;
            }

            IUserEntity userForRegister = new UserEntity(login, password);

            return UserRepository.Add(userForRegister);
        }

        public bool TryLogInUser(string login, string password, out string errorText)
        {
            errorText = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                errorText = "Пустое поле логина или пароля";
                return false;
            }

            password = HashConverter.ToHashString(password);

            var user = (from x in UserRepository.GetAll()
                       where x.Login == login && x.Password == password
                       select x).FirstOrDefault();

            if (user == null)
            {
                errorText = "Неверный логин или пароль";
                return false;
            }
            
            _currentUser = user;

            return true;
        }
    }
}
