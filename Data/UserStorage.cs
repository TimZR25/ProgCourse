using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    internal abstract class UserStorage : IBaseStorage<UserEntity>
    {
        protected List<UserEntity> _users = new();

        public bool Add(UserEntity user)
        {
            if (user == null || Contains(user)) return false;

            _users.Add(user);

            return true;
        }

        public bool Remove(UserEntity entity)
        {
            if (!_users.Contains(entity)) return false;

            _users.Remove(entity);

            return true;
        }

        public ReadOnlyCollection<UserEntity> GetAll()
        {
            return _users.AsReadOnly();
        }

        public bool Contains(UserEntity entity)
        {
            if (_users.Count <= 0) return false;

            foreach (UserEntity user in _users)
            {
                if (entity.Login != user.Login) return false;
                if (entity.Password != user.Password) return false;
            }

            return true;
        }

        public abstract bool Load();
        public abstract bool Save();
    }
}
