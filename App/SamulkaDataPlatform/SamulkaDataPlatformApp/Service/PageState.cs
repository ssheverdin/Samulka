using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamulkaDataPlatformApp.Service
{
    public class PageState
    {
        private string _pageTitle;
        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
                NotifyDataChanged();
            }
        }

        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
