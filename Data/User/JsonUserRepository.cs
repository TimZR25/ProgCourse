using Newtonsoft.Json;
using ProgCourse.User;

namespace ProgCourse.Data.User
{
    public class JsonUserRepository : UserRepository
    {
        private string _path;

        public JsonUserRepository(string path)
        {
            _path = path;
        }

        public override bool Load()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            var users = File.Exists(_path)
                ? JsonConvert.DeserializeObject<List<IUserEntity>>(File.ReadAllText(_path), settings)
                : null;

            if (users == null) return false;

            _users = users;

            return true;
        }

        public override bool Save()
        {
            if (_users.Count < 0) return false;

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            File.WriteAllText(_path, JsonConvert.SerializeObject(_users, Formatting.Indented, settings));

            return true;
        }
    }
}
