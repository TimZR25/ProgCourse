using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Models;

namespace ProgCourse.Data
{
    public interface IDataManager
    {
        public IBaseStorage<IUserEntity> UserStorage { get; set; }
        public IUserEntity? CurrentUser { get; set; }

        public void LoadAll();
        public void SaveAll();

        public bool TrySignUpUser(string login, string password, out string errorText);
        public bool TryLogInUser(string login, string password, out string errorText);
    }
}
