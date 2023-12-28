using Newtonsoft.Json;
using ProgCourse.Data;
using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenters;
using ProgCourse.Views;
using System.Windows.Forms.VisualStyles;

namespace ProgCourse
{
    public partial class LogInForm : Form, ILogInView
    {
        public string Login => textBoxLogin.Text;
        public string Password => textBoxPassword.Text;

        public IViewsProvider ViewsProvider { get; }

        public event Action? OnViewClosed;

        private ILogInPresenter _presenter;

        public LogInForm(IViewsProvider viewsProvider, ILogInPresenter logInPresenter)
        {
            InitializeComponent();

            ViewsProvider = viewsProvider;

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            _presenter = logInPresenter;

            _presenter.OnErrored += ShowError;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            labelError.Hide();

            if (_presenter.TryLogIn() == true) ViewsProvider.Show(ViewType.FilmMenu);
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            ViewsProvider.Show(ViewType.SignUp);
        }

        private void checkBoxPasswordView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxPasswordView.Checked;
        }

        private void ShowError(object? sender, string message)
        {
            labelError.Text = message;
            labelError.Show();
        }
    }
}