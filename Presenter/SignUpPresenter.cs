using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenter
{
    public class SignUpPresenter
    {
        private SignUpForm _form;

        public EventHandler<string>? OnErrored;

        public SignUpPresenter(SignUpForm form)
        {
            _form = form;

            _form.OnClicked += SignUp;
        }

        private void SignUp(object? sender, EventArgs e)
        {
            string error = string.Empty;

            if (!Program.DataManager.TrySignUpUser(_form.Login, _form.Password))
            {
                OnErrored?.Invoke(this, "Такой пользователь уже существует");
                return;
            }

            Program.DataManager.SaveAll();

            _form.Close();
        }
    }
}
