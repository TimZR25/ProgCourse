using ProgCourse.CinemaHallFolder.CinemaHallHost.Service;
using ProgCourse.CinemaHallFolder.Presenter;
using ProgCourse.CinemaHallFolder.Service;
using ProgCourse.CinemaHallFolder.View;
using ProgCourse.Data;
using ProgCourse.Data.CinemaHall;
using ProgCourse.Data.FilmSession;
using ProgCourse.Data.User;
using ProgCourse.FilmSession.FilmMenu.Presenter;
using ProgCourse.FilmSession.FilmMenu.Service;
using ProgCourse.FilmSession.FilmMenu.View;
using ProgCourse.FilmSession.FilmSessionHost.Presenter;
using ProgCourse.FilmSession.FilmSessionHost.Service;
using ProgCourse.FilmSession.FilmSessionHost.View;
using ProgCourse.LogIn.Presenter;
using ProgCourse.LogIn.Service;
using ProgCourse.LogIn.View;
using ProgCourse.SignUp.Presenter;
using ProgCourse.SignUp.Service;
using ProgCourse.SignUp.View;
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
            UserRepository userRepository = new JsonUserRepository("users.json");
            CinemaHallRepository cinemaHallRepository = new JSONCinemaHallRepository("cinemaHalls.json");
            FilmSessionRepository filmSessionRepository = new JSONFilmRepository("filmSessions.json");

            DataManager dataManager = new DataManager(userRepository, cinemaHallRepository, filmSessionRepository);


            ISignUpService signUpService = new SignUpService(dataManager.UserRepository);
            ILogInService logInService = new LogInService(dataManager.UserRepository);
            ICinemaHallService cinemaService = new CinemaHallService(dataManager.CinemaHallRepository);
            IFilmMenuService filmMenuService = new FilmMenuService(dataManager.FilmSessionRepository);
            IFilmSessionHostService filmSessionHostService = new FilmSessionHostService(dataManager.FilmSessionRepository, dataManager.CinemaHallRepository);
            ICinemaHallHostService cinemaHallHostService = new CinemaHallHostService(dataManager.CinemaHallRepository);


            dataManager.LoadAll();


            ISignUpPresenter signUpPresenter = new SignUpPresenter(signUpService);
            ILogInPresenter logInPresenter = new LogInPresenter(logInService);
            ICinemaHallPresenter cinemaHallPresenter = new CinemaHallPresenter(cinemaService);
            IFilmMenuPresenter filmMenuPresenter = new FilmMenuPresenter(cinemaService, filmMenuService, logInService);
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