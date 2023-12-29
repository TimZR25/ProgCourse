using System.Windows.Forms;

namespace ProgCourse.Views
{
    public interface IFilmSessionHostView : IView
    {
        TextBox FilmName { get; }
        ComboBox HallID { get; }
        DateTimePicker Duration { get; }
        DateTimePicker Date {  get; }
        DateTimePicker StartTime { get; }
    }
}