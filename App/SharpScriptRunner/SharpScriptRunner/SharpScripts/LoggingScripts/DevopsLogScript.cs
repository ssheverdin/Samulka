using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using SharpScriptCore;

namespace SharpScripts.LoggingScripts
{
    public class DevopsLogScript : SharpScript
    {
        public override string Execute()
        {
            Logger.LogInformation("this is script");
            return "Script ended";
        }

        public DevopsLogScript(ILogger logger) : base(logger)
        {
        }
    }
}
