using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    internal interface IDataManager
    {
        public UserStorage UserStorage { get; }
        public UserEntity? CurrentUser { get; }

        public void LoadAll();
        public void SaveAll();

        public bool TrySignUpUser(string login, string password);
        public bool TryLogInUser(string login, string password);
    }
}
