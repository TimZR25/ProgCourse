using ProgCourse.Views;

namespace ProgCourse.LogIn.View
{
    public interface ILogInView : IView
    {
        string Login { get; }
        string Password { get; }
    }
}
