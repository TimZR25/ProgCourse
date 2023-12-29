using ProgCourse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Models
{
    public class UserEntity : IUserEntity
    {
        public string Login { get; }
        public string Password { get; }

        public LevelUserAccess LevelUserAccess { get; }

        public UserEntity(string login, string password, LevelUserAccess levelUserAccess)
        {
            Login = login;
            Password = password;
            LevelUserAccess = levelUserAccess;
        }
    }
}
