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
        public NumericUpDown HallID => numericUpDownHallID;
        public DateTimePicker Duration => dateTimePickerDuration;
        public DateTimePicker Date => dateTimePicker1;


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
    }
}
