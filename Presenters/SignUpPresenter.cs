using Microsoft.VisualBasic.Logging;
using ProgCourse.Data;
using ProgCourse.Forms;
using ProgCourse.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public class SignUpPresenter : ISignUpPresenter
    {
        IDataManager _dataManager;

        private ISignUpView? _view;
        public IView? View => _view;

        public event EventHandler<string>? OnErrored;

        public SignUpPresenter(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void Init(ISignUpView view)
        {
            _view = view;
        }

        public bool TrySignUp()
        {
            if (_view == null) return false;

            string error = string.Empty;

            if (_dataManager.TrySignUpUser(_view.Login, _view.Password, out string errorText) == false)
            {
                OnErrored?.Invoke(this, errorText);
                return false;
            }

            _dataManager.SaveAll();

            return true;
        }
    }
}
