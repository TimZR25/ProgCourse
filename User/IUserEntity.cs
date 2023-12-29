using ProgCourse.Data;

namespace ProgCourse.User
{
    public interface IUserEntity : IEntity
    {
        string Login { get; }
        string Password { get; }
        LevelUserAccess LevelUserAccess { get; }
    }
}
