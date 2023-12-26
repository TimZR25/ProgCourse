using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Forms;

namespace ProgCourse.Presenter
{
    public class LogInPresenter
    {
        private ILogInForm _form;

        public event EventHandler<string>? OnErrored;
        public event EventHandler? OnLogging;

        public LogInPresenter(LogInForm form)
        {
            _form = form;
        }

        public bool LogIn()
        {
            if (!Program.DataManager.TryLogInUser(_form.Login, _form.Password))
            {
                OnErrored?.Invoke(this, "Неправильный логин или пароль");
                return false;
            }

            return true;
        }
    }
}
