using ProgCourse.Forms;
using ProgCourse.Models;
using ProgCourse.Presenters;

namespace ProgCourse
{
    public partial class SignUpForm : Form, ISignUpView
    {
        private ISignUpPresenter _presenter;

        public string Login => textBoxLogin.Text;
        public string Password => textBoxPassword.Text;

        public IViewsProvider ViewsProvider { get; }

        public event Action? OnViewClosed;

        public SignUpForm(IViewsProvider viewsProvider, ISignUpPresenter signUpPresenter)
        {
            InitializeComponent();

            ViewsProvider = viewsProvider;

            FormClosed += (_, _) => OnViewClosed?.Invoke();

            _presenter = signUpPresenter;

            _presenter.OnErrored += ShowError;

            Closed += ResetFields;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            labelError.Hide();

            if (_presenter.TrySignUp() == true) Close();
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

        private void ResetFields(object? sender, EventArgs eventArgs)
        {
            textBoxLogin.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        void IView.ShowDialog()
        {
            ShowDialog();
        }
    }
}