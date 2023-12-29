using ProgCourse.SignUp.View;

namespace ProgCourse.SignUp.Presenter
{
    public interface ISignUpPresenter
    {
        void Init(ISignUpView view);
        event EventHandler<string>? OnErrored;

        bool TrySignUp();
    }
}
