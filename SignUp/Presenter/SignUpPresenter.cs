﻿using ProgCourse.SignUp.Service;
using ProgCourse.SignUp.View;

namespace ProgCourse.SignUp.Presenter
{
    public class SignUpPresenter : ISignUpPresenter
    {
        private ISignUpService _signUpService;

        private ISignUpView? _view;

        public event EventHandler<string>? OnErrored;

        public SignUpPresenter(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        public void Init(ISignUpView view)
        {
            _view = view;
        }

        public bool TrySignUp()
        {
            if (_view == null) return false;

            string error = string.Empty;

            if (_signUpService.TrySignUpUser(_view.Login, _view.Password, out string errorText) == false)
            {
                OnErrored?.Invoke(this, errorText);
                return false;
            }

            return true;
        }
    }
}
