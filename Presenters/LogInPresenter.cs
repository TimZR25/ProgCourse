using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data;
using ProgCourse.Views;
using ProgCourse.Services;

namespace ProgCourse.Presenters
{
    public class LogInPresenter : ILogInPresenter
    {
        private ILogInService _logInService;

        private ILogInView? _view;

        public event EventHandler<string>? OnErrored;

        public LogInPresenter(ILogInService logInService)
        {
            _logInService = logInService;
        }

        public void Init(ILogInView view)
        {
            _view = view;
        }

        public bool TryLogIn()
        {
            if (_view == null) return false;

            if (_logInService.TryLogInUser(_view.Login, _view.Password, out string errorText) == false)
            {
                OnErrored?.Invoke(this, errorText);
                return false;
            }

            return true;
        }
    }
}
