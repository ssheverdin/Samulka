using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleExtensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConsoleParamAttribute : Attribute
    {
        public string Name { get; set; }
        public bool Required { get; set; }

        public ConsoleParamAttribute(string name)
        {
            Name = name;
            Required = false;
        }

        public ConsoleParamAttribute(string name, bool required)
        {
            Name = name;
            Required = required;
        }
    }
    
}
