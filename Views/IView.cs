namespace ProgCourse.Forms
{
    public interface IView
    {
        public IViewsProvider ViewsProvider { get; }

        public event Action? OnViewClosed;

        public void Dispose();
        public void ShowDialog();
        public void Show();
        public void Hide();
        public void Close();
    }
}
