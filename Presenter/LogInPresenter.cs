using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenter
{
    internal class LogInPresenter
    {
        private LogInForm _form;

        public EventHandler<string>? OnErrored;

        public LogInPresenter(LogInForm form)
        {
            _form = form;

            _form.OnClicked += LogIn;
        }

        private void LogIn(object? sender, EventArgs e)
        {
            if (!Program.DataManager.TryLogInUser(_form.Login, _form.Password))
            {
                OnErrored?.Invoke(this, "Неправильный логин или пароль");
                return;
            }

            _form.Close();
        }
    }
}
