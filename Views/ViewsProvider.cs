using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Forms
{
    public class ViewsProvider : IViewsProvider
    {
        private Dictionary<ViewType, IView> _views = new Dictionary<ViewType, IView>();

        private IView? _previousView;
        private IView? _currentView;

        public IView? CurrentView => _currentView;

        public void Register(ViewType viewType, IView view)
        {
            _views.Add(viewType, view);
        }

        public void SetCurrentView(ViewType viewType)
        {
            if (!_views.ContainsKey(viewType)) return;

            _currentView = _views[viewType];
        }

        public void Show(ViewType viewType)
        {
            if (!_views.ContainsKey(viewType)) return;

            if (_currentView != null)
            {
                _previousView = _currentView;
                _previousView?.Hide();
            }

            _currentView = _views[viewType];

            if (_previousView != null) _currentView.OnViewClosed += ShowDialog;

            _currentView.ShowDialog();
        }

        private void ShowDialog()
        {
            _previousView?.Show();
            _currentView = _previousView;
        }
    }
}
