using Newtonsoft.Json;
using ProgCourse.Data;
using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenter;
using System.Windows.Forms.VisualStyles;

namespace ProgCourse
{
    public partial class LogInForm : Form, ILogInForm
    {
        private LogInPresenter _presenter;

        public string Login => textBoxLogin.Text;
        public string Password => textBoxPassword.Text;

        public event EventHandler? OnClicked;

        public LogInForm()
        {
            InitializeComponent();

            _presenter = new LogInPresenter(this);

            _presenter.OnErrored += ShowError;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            labelError.Hide();

            if (_presenter.LogIn() == true) Close();
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(this);
            signUpForm.ShowDialog();
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