﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Forms
{
    public interface ISignUpView : IView
    {
        string Login { get; }
        string Password { get; }
    }
}
