using ProgCourse.User;

namespace ProgCourse.LogIn.Service
{
    public interface ILogInService
    {
        IUserEntity? CurrentUser { get; }

        bool TryLogInUser(string login, string password, out string errorText);
    }
}