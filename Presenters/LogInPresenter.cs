using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgCourse.Data;
using ProgCourse.Forms;

namespace ProgCourse.Presenters
{
    public class LogInPresenter : ILogInPresenter
    {
        private IDataManager _dataManager;

        private ILogInView? _view;
        public IView? View => _view;

        public event EventHandler<string>? OnErrored;
        public event EventHandler? OnLogging;

        public LogInPresenter(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Init(ILogInView view)
        {
            _view = view;
        }

        public bool TryLogIn()
        {
            if (_view == null) return false;

            if (_dataManager.TryLogInUser(_view.Login, _view.Password, out string errorText) == false)
            {
                OnErrored?.Invoke(this, errorText);
                return false;
            }

            return true;
        }
    }
}
