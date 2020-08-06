using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NetCoreConsoleExtensions;
using SharpScriptCore;


namespace SharpScriptRunner
{


    public class SharpScriptConsoleContainer : ConsoleContainer, ISharpScriptConsoleContainer
    {
        public SharpScriptConsoleContainer(ILogger<ConsoleContainer> logger) : base(logger)
        {
        }

        public override void RunContainer(List<string> containerArguments)
        {
            _logger.LogInformation("Container Running");
        }

        public override List<Type> GetAllExecutables()
        {
            throw new NotImplementedException();
        }
    }
}
