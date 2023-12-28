using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.FilmSession;
using ProgCourse.Data.User;
using ProgCourse.Forms;
using ProgCourse.Presenters;
using ProgCourse.Services;
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
            CinemaHallRepository cinemaHallRepository = new JSONCinemaHallRepository("cinemaHalls.json");
            FilmSessionRepository filmSessionRepository = new JSONFilmRepository("filmSessions.json");

            DataManager dataManager = new DataManager(userStorage, cinemaHallRepository, filmSessionRepository);

            ISignUpService signUpService = new SignUpService(dataManager.UserRepository);
            ILogInService logInService = new LogInService(dataManager.UserRepository);
            ICinemaHallService cinemaService = new CinemaHallService(dataManager.CinemaHallRepository);

            dataManager.LoadAll();

            ISignUpPresenter signUpPresenter = new SignUpPresenter(signUpService);
            ILogInPresenter logInPresenter = new LogInPresenter(logInService);
            ICinemaHallPresenter cinemaHallPresenter = new CinemaHallPresenter(cinemaService);
            IFilmMenuPresenter filmMenuPresenter = new FilmMenuPresenter(cinemaService, dataManager.FilmSessionRepository);

            ILogInView logInView = new LogInForm(viewsProvider, logInPresenter);
            ISignUpView signUpView = new SignUpForm(viewsProvider, signUpPresenter);
            ICinemaHallView cinemaHallView = new CinemaHallView(viewsProvider, cinemaHallPresenter);
            IFilmMenuView filmMenuForm = new FilmMenuForm(viewsProvider, filmMenuPresenter);

            logInPresenter.Init(logInView);
            signUpPresenter.Init(signUpView);
            cinemaHallPresenter.Init(cinemaHallView);

            viewsProvider.Register(ViewType.LogIn, logInView);
            viewsProvider.Register(ViewType.SignUp, signUpView);
            viewsProvider.Register(ViewType.CinemaHall, cinemaHallView);
            viewsProvider.Register(ViewType.FilmMenu, filmMenuForm);

            //new CinemaHallHostService(cinemaHallRepository).TryAddCinemaHall(1, 5, 120);
            //new FilmSessionHostService(filmSessionRepository).TryAddFilmSession(3, "Batman", DateTime.Now, new TimeOnly(1, 0));

            viewsProvider.SetCurrentView(ViewType.LogIn);
            Application.Run(viewsProvider.CurrentView as Form);
        }
    }
}