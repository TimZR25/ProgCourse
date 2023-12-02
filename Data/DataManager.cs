using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Models;
using ProgCourse.Utilities;

namespace ProgCourse.Data
{
    internal class DataManager : IDataManager
    {
        private UserEntity? _currentUser = null;

        public UserStorage UserStorage {  get; }
        public UserEntity? CurrentUser => _currentUser;

        public DataManager(UserStorage userStorage)
        {
            UserStorage = userStorage;
        }

        public void LoadAll()
        {
            UserStorage.Load();
        }

        public void SaveAll()
        {
            UserStorage.Save();
        }

        public bool TrySignUpUser(string login, string password)
        {
            password = HashConverter.ToHashString(password);

            UserEntity user = new UserEntity(login, password);

            return UserStorage.Add(user);
        }

        public bool TryLogInUser(string login, string password)
        {
            password = HashConverter.ToHashString(password);

            var user = (from x in UserStorage.GetAll()
                       where x.Login == login && x.Password == password
                       select x).FirstOrDefault();

            if (user == null) return false;
            
            _currentUser = user;

            return true;
        }
    }
}
