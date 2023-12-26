using Newtonsoft.Json;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data
{
    public class JsonUserStorage : UserStorage
    {
        private string _path;

        private JsonSerializerSettings _settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public JsonUserStorage(string path)
        {
            _path = path;
        }

        public override bool Load()
        {
            var users = File.Exists(_path)
                ? JsonConvert.DeserializeObject<List<IUserEntity>>(File.ReadAllText(_path), _settings)
                : null;

            if (users == null) return false;

            _users = users;

            return true;
        }

        public override bool Save()
        {
            if (_users.Count <= 0) return false;

            File.WriteAllText("users.json", JsonConvert.SerializeObject(_users, Formatting.Indented, _settings));

            return true;
        }
    }
}
