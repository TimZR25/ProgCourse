using ProgCourse.Views;

namespace ProgCourse.FilmSession.FilmMenu.View
{
    public interface IFilmMenuView : IView
    {
        ListView ListViewSessions { get; }
    }
}
