using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace NetCoreConsoleExtensions
{
    public abstract class ConsoleContainer : IConsoleContainer
    {
        protected ILogger<ConsoleContainer> _logger;

        protected ConsoleContainer(ILogger<ConsoleContainer> logger)
        {
            _logger = logger;
        }

        public void Run(List<string> arguments)
        {
            _logger.LogDebug($"Start {this.GetType().ToString()} Container");

            RunContainer(arguments);

            _logger.LogDebug($"Stop {this.GetType().ToString()} Container");
        }

        public abstract void RunContainer(List<string> containerArguments);
        public abstract List<Type> GetAllExecutables();
    }
}
