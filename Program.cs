using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.FilmSession;
using ProgCourse.Data.User;
using ProgCourse.Views;
using ProgCourse.Presenters;
using ProgCourse.Services;

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
            IFilmMenuService filmMenuService = new FilmMenuService(dataManager.FilmSessionRepository);
            IFilmSessionHostService filmSessionHostService = new FilmSessionHostService(filmSessionRepository, cinemaHallRepository);

            dataManager.LoadAll();

            ISignUpPresenter signUpPresenter = new SignUpPresenter(signUpService);
            ILogInPresenter logInPresenter = new LogInPresenter(logInService);
            ICinemaHallPresenter cinemaHallPresenter = new CinemaHallPresenter(cinemaService);
            IFilmMenuPresenter filmMenuPresenter = new FilmMenuPresenter(cinemaService, filmMenuService);
            IFilmSessionHostPresenter filmSessionHostPresenter = new FilmSessionHostPresenter(filmSessionHostService);

            ILogInView logInView = new LogInForm(viewsProvider, logInPresenter);
            ISignUpView signUpView = new SignUpForm(viewsProvider, signUpPresenter);
            ICinemaHallView cinemaHallView = new CinemaHallView(viewsProvider, cinemaHallPresenter);
            IFilmMenuView filmMenuView = new FilmMenuForm(viewsProvider, filmMenuPresenter);
            IFilmSessionHostView filmSessionHostView = new FilmSessionHostForm(viewsProvider, filmSessionHostPresenter);

            logInPresenter.Init(logInView);
            signUpPresenter.Init(signUpView);
            cinemaHallPresenter.Init(cinemaHallView);
            filmMenuPresenter.Init(filmMenuView);
            filmSessionHostPresenter.Init(filmSessionHostView);

            viewsProvider.Register(ViewType.LogIn, logInView);
            viewsProvider.Register(ViewType.SignUp, signUpView);
            viewsProvider.Register(ViewType.CinemaHall, cinemaHallView);
            viewsProvider.Register(ViewType.FilmMenu, filmMenuView);
            viewsProvider.Register(ViewType.FilmSessionHost, filmSessionHostView);

            viewsProvider.SetCurrentView(ViewType.LogIn); 
            Application.Run(viewsProvider.CurrentView as Form);
        }
    }
}