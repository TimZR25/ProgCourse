using ProgCourse.Data.CinemaHall;
using ProgCourse.Presenters;
using ProgCourse.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgCourse.Views
{
    public partial class FilmSessionHostForm : Form, IFilmSessionHostView
    {
        public IViewsProvider ViewsProvider { get; }

        public TextBox FilmName => textBoxFilmName;
        public ComboBox HallID => comboBoxHallID;
        public DateTimePicker Duration => dateTimePickerDuration;
        public DateTimePicker Date => dateTimePickerDate;
        public DateTimePicker StartTime => dateTimePickerStartTime;


        public event Action? OnViewClosed;

        private IFilmSessionHostPresenter _presenter;

        public FilmSessionHostForm(IViewsProvider viewsProvider, IFilmSessionHostPresenter presenter)
        {
            InitializeComponent();

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            ViewsProvider = viewsProvider;
            _presenter = presenter;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_presenter.TryAddFilmSession())
                Close();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            comboBoxHallID.Items.Clear();

            foreach (ICinemaHallEntity hallEntity in _presenter.FilmSessionHostService.ReservedHalls)
            {
                comboBoxHallID.Items.Add(hallEntity.Number);
            }

        }
    }
}
