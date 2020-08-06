using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace SharpScriptCore
{
    public abstract class SharpScript : ISharpScript
    {
        protected ILogger Logger;

        protected SharpScript(ILogger logger)
        {
            Logger = logger;
        }

        public SharpScriptResult ExecuteScript()
        {
            try
            {
                return new SharpScriptResult()
                {
                    Success = true,
                    ExecutionMessage = Execute()
                };
            }
            catch (Exception e)
            {
                return  new SharpScriptResult()
                {
                    Success = false,
                    ExecutionMessage = e.Message
                };
            }
        }

        public abstract string Execute();
    }
}
