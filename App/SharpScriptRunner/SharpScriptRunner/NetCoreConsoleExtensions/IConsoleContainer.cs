using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleExtensions
{
    public interface IConsoleContainer
    {
        void Run(List<string> arguments);
    }
}
