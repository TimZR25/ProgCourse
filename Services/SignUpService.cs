using ProgCourse.Data;
using ProgCourse.Data.User;
using ProgCourse.Models;
using ProgCourse.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Services
{
    public class SignUpService : ISignUpService
    {
        private IBaseRepository<IUserEntity> _userRepository;

        public SignUpService(IBaseRepository<IUserEntity> userRepository)
        {
            _userRepository = userRepository;
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

            var user = (from x in _userRepository.GetAll()
                        where x.Login == login && x.Password == password
                        select x).FirstOrDefault();

            if (user != null)
            {
                errorText = "Такой пользователь уже существует";
                return false;
            }

            IUserEntity userForRegister = new UserEntity(login, password, LevelUserAccess.Cashier);

            if (_userRepository.Add(userForRegister))
            {
                _userRepository.Save();
                return true;
            }

            return false;
        }
    }
}
