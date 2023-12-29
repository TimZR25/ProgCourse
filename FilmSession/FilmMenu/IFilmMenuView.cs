using ProgCourse.Views;

namespace ProgCourse.FilmSession.FilmMenu
{
    public interface IFilmMenuView : IView
    {
        ListView ListViewSessions { get; }
    }
}
