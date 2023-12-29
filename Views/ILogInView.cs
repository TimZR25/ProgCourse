﻿using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Views
{
    public interface ILogInView : IView
    {
        string Login { get; }
        string Password { get; }
    }
}
