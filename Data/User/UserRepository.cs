using ProgCourse.User;

namespace ProgCourse.Data.User
{
    public abstract class UserRepository : IBaseRepository<IUserEntity>
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

        public bool RemoveAll()
        {
            if (_users.Count <= 0) return false;

            _users.Clear();

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
