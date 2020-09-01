using Microsoft.AspNetCore.Components;
using SamulkaDataPlatformApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamulkaDataPlatformApp.Pages
{
    public partial class Counter : StatePageComponent
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }

        public override string PageTitle => "Counter";
    }
}
