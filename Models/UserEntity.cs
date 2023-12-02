using ProgCourse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Models
{
    internal class UserEntity : IUserEntity
    {
        public string Login { get; }
        public string Password { get; }

        public UserEntity(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
