using ProgCourse.LogIn.View;

namespace ProgCourse.LogIn.Presenter
{
    public interface ILogInPresenter
    {
        void Init(ILogInView view);
        bool TryLogIn();
        event EventHandler<string>? OnErrored;
    }
}
