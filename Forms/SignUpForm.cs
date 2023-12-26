using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenter;

namespace ProgCourse
{
    public partial class SignUpForm : Form, ISignUpForm
    {
        private Form _previousForm;

        private SignUpPresenter _presenter;

        public string Login => textBoxLogin.Text;
        public string Password => textBoxPassword.Text;

        public event EventHandler? OnClicked;

        public SignUpForm(Form previous)
        {
            _previousForm = previous;
            _previousForm.Hide();
            FormClosed += OnClosed;

            InitializeComponent();

            _presenter = new SignUpPresenter(this);
            _presenter.OnErrored += ShowError;
        }

        private void OnClosed(object? sender, FormClosedEventArgs e)
        {
            _previousForm.Show();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            labelError.Hide();

            OnClicked?.Invoke(this, e);
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