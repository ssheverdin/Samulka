using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamulkaDataPlatformApp.Service
{
    public abstract class StatePageComponent : ComponentBase, IDisposable
    {
        [Inject]
        protected PageState _pageState { get; set; }

        protected override void OnInitialized()
        {
            _pageState.PageTitle = PageTitle;
            _pageState.OnChange += StateHasChanged;
            base.OnInitialized();
        }

        public void Dispose()
        {
            _pageState.OnChange -= StateHasChanged;
        }

        public abstract string PageTitle { get; }

    }
}
