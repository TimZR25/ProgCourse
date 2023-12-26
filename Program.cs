using ProgCourse.Data;
using ProgCourse.Forms;
using ProgCourse.Presenters;

namespace ProgCourse
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ViewsProvider viewsProvider = new ViewsProvider();
            UserStorage userStorage = new JsonUserStorage("users.json");
            DataManager dataManager = new DataManager(userStorage);

            dataManager.LoadAll();

            ISignUpPresenter signUpPresenter = new SignUpPresenter(dataManager);
            ILogInPresenter logInPresenter = new LogInPresenter(dataManager);

            ILogInView logInView = new LogInForm(viewsProvider, logInPresenter);
            ISignUpView signUpView = new SignUpForm(viewsProvider, signUpPresenter);

            logInPresenter.Init(logInView);
            signUpPresenter.Init(signUpView);

            viewsProvider.Register(ViewType.LogIn, logInView);
            viewsProvider.Register(ViewType.SignUp, signUpView);

            viewsProvider.SetCurrentView(ViewType.LogIn);

            Application.Run(viewsProvider.CurrentView as Form);
        }
    }
}