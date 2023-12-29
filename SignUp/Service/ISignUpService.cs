namespace ProgCourse.SignUp.Service
{
    public interface ISignUpService
    {
        bool TrySignUpUser(string login, string password, out string errorText);
    }
}