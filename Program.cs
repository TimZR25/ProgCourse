using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.User;
using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenters;
using ProgCourse.Views;

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
            UserRepository userStorage = new JsonUserRepository("users.json");
            CinemaHallRepository cinemaHallRepositories = new JSONCinemaHallRepository("cinemaHalls.json");

            DataManager dataManager = new DataManager(userStorage, cinemaHallRepositories);


            dataManager.LoadAll();

            ISignUpPresenter signUpPresenter = new SignUpPresenter(dataManager);
            ILogInPresenter logInPresenter = new LogInPresenter(dataManager);
            ICinemaHallPresenter cinemaHallPresenter = new CinemaHallPresenter(dataManager);

            ILogInView logInView = new LogInForm(viewsProvider, logInPresenter);
            ISignUpView signUpView = new SignUpForm(viewsProvider, signUpPresenter);
            ICinemaHallView cinemaHallView = new CinemaHallView(viewsProvider, cinemaHallPresenter);

            logInPresenter.Init(logInView);
            signUpPresenter.Init(signUpView);
            cinemaHallPresenter.Init(cinemaHallView);

            viewsProvider.Register(ViewType.LogIn, logInView);
            viewsProvider.Register(ViewType.SignUp, signUpView);
            viewsProvider.Register(ViewType.CinemaHall, cinemaHallView);

            int sideSize = 10, hallNumber = 0;

            dataManager.CinemaHallRepository.Add(new CinemaHall(hallNumber, sideSize));

            dataManager.SaveAll();

            cinemaHallPresenter.InitCinemaHall(hallNumber);

            viewsProvider.SetCurrentView(ViewType.CinemaHall);
            Application.Run(viewsProvider.CurrentView as Form ?? null);
        }
    }
}