using ProgCourse.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public interface ISignUpPresenter : IPresenter
    {
        public void Init(ISignUpView view);
        public event EventHandler<string>? OnErrored;

        public bool TrySignUp();
    }
}
