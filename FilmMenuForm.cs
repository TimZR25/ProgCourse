using ProgCourse.Data;
using ProgCourse.Data.FilmSession;
using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenters;
using ProgCourse.Views;


namespace ProgCourse
{
    public partial class FilmMenuForm : Form, IFilmMenuView
    {
        private int _index = 0;

        public event Action? OnViewClosed;

        public IViewsProvider ViewsProvider { get; }

        private IFilmMenuPresenter _presenter;

        public FilmMenuForm(IViewsProvider viewsProvider, IFilmMenuPresenter presenter)
        {
            InitializeComponent();

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            ViewsProvider = viewsProvider;

            _presenter = presenter;
        }

        private void buttonNavigate_Click(object sender, EventArgs e)
        {
            if (_presenter.CinemaHallService.TrySetIndexHall(_index))
                ViewsProvider.Show(ViewType.CinemaHall);
        }

        private void Init()
        {
            listViewSessions.Items.Clear();
            _presenter.CinemaHallService.TrySetIndexHall(0);

            List<IFilmSessionEntity> filmSessions = new List<IFilmSessionEntity>(_presenter.FilmSessionRepository.GetAll());

            for (int i = 0; i < filmSessions.Count; i++)
            {
                listViewSessions.Items.Add(filmSessions[i].HallID.ToString());
                listViewSessions.Items[i].SubItems.Add(filmSessions[i].FilmName);

                TimeOnly startTime = new TimeOnly(filmSessions[i].DateStart.Hour, filmSessions[i].DateStart.Minute);

                TimeOnly endTime = startTime.AddHours(filmSessions[i].Duration.Hour);
                TimeOnly minuteBuff = new TimeOnly(0, startTime.Minute);
                TimeOnly timeBuff = minuteBuff.AddMinutes(filmSessions[i].Duration.Minute);
                endTime = new TimeOnly(endTime.AddHours(timeBuff.Hour).Hour, timeBuff.Minute);

                listViewSessions.Items[i].SubItems.Add($"{startTime} : {endTime}");
                listViewSessions.Items[i].SubItems.Add(filmSessions[i].DateStart.Date.ToShortDateString());
            }

        }

        private void listViewSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSessions.SelectedItems.Count <= 0) return;

            _index = int.Parse(listViewSessions.SelectedItems[0].Text);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Init();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Exit();
        }
    }
}
