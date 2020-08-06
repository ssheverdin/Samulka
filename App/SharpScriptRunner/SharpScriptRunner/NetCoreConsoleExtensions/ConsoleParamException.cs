using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleExtensions
{
    public class ConsoleParamException : Exception
    {
        public ConsoleParamException() : base("Wrong input for console parameters")
        {
        }

        public ConsoleParamException(string message) : base(message)
        {
        }
    }
}
