namespace ProgCourse.Views
{
    public interface IView
    {
        IViewsProvider ViewsProvider { get; }

        event Action? OnViewClosed;

        void Dispose();
        DialogResult ShowDialog();
        void Show();
        void Hide();
        void Close();
    }
}
