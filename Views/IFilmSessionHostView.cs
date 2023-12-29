using System.Windows.Forms;

namespace ProgCourse.Views
{
    public interface IFilmSessionHostView : IView
    {
        TextBox FilmName { get; }
        NumericUpDown HallID { get; }
        DateTimePicker Duration { get; }
        DateTimePicker Date {  get; }
    }
}