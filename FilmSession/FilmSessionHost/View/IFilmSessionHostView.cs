using ProgCourse.Views;

namespace ProgCourse.FilmSession.FilmSessionHost.View
{
    public interface IFilmSessionHostView : IView
    {
        TextBox FilmName { get; }
        ComboBox HallID { get; }
        DateTimePicker Duration { get; }
        DateTimePicker Date { get; }
        DateTimePicker StartTime { get; }
    }
}