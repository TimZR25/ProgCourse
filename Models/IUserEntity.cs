using ProgCourse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Models
{
    public interface IUserEntity : IEntity
    {
        string Login { get; }
        string Password { get; }
        LevelUserAccess LevelUserAccess { get; }
    }
}
