using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Forms
{
    public interface IViewsProvider
    {
        public IView? CurrentView { get; }

        public void Register(ViewType viewType, IView view);

        public void Show(ViewType viewType);
    }

    public enum ViewType
    {
        LogIn, SignUp
    }
}
