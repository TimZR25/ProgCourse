namespace ProgCourse.Services
{
    public interface ISignUpService
    {
        bool TrySignUpUser(string login, string password, out string errorText);
    }
}