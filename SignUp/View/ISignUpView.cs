using ProgCourse.Views;

namespace ProgCourse.SignUp.View
{
    public interface ISignUpView : IView
    {
        string Login { get; }
        string Password { get; }
    }
}
