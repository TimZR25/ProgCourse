using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IBaseStorage<IUserEntity> UserStorage {  get; set; }

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

            IUserEntity user = new UserEntity(login, password);

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
