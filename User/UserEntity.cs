namespace ProgCourse.User
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
