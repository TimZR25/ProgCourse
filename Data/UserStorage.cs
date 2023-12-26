using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    public abstract class UserStorage : IBaseStorage<IUserEntity>
    {
        protected List<IUserEntity> _users = new();

        public bool Add(IUserEntity user)
        {
            if (user == null || Contains(user)) return false;

            _users.Add(user);

            return true;
        }

        public bool Remove(IUserEntity entity)
        {
            if (!_users.Contains(entity)) return false;

            _users.Remove(entity);

            return true;
        }

        public IReadOnlyCollection<IUserEntity> GetAll()
        {
            return _users.AsReadOnly();
        }

        public bool Contains(IUserEntity entity)
        {
            if (_users.Count <= 0) return false;

            foreach (IUserEntity user in _users)
            {
                if (entity.Login == user.Login) return true;
            }

            return false;
        }

        public abstract bool Load();
        public abstract bool Save();
    }
}
