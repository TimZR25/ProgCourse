using ProgCourse.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public interface ILogInPresenter
    {
        void Init(ILogInView view);
        bool TryLogIn();
        event EventHandler<string>? OnErrored;
    }
}
