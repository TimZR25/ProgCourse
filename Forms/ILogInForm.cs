using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Forms
{
    public interface ILogInForm
    {
        public string Login { get; }
        public string Password { get; }

        public event EventHandler? OnClicked;
    }
}
