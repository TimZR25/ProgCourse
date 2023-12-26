using ProgCourse.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Presenters
{
    public interface ILogInPresenter : IPresenter
    {
        public void Init(ILogInView view);
        public bool TryLogIn();
        public event EventHandler<string>? OnErrored;
        public event EventHandler? OnLogging;
    }
}
