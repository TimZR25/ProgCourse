using ProgCourse.Models;

namespace ProgCourse.Services
{
    public interface ILogInService
    {
        IUserEntity? CurrentUser { get; }

        bool TryLogInUser(string login, string password, out string errorText);
    }
}