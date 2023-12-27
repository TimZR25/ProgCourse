using ProgCourse.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public interface ISignUpPresenter
    {
        void Init(ISignUpView view);
        event EventHandler<string>? OnErrored;

        bool TrySignUp();
    }
}
