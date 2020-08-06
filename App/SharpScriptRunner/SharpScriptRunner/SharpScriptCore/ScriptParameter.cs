using System;
using System.Collections.Generic;
using System.Text;

namespace SharpScriptCore
{
    public class ScriptParameter
    {
        public Type Type { get; set; }
        public object Value { get; set; }
        public bool Required { get; set; }
    }
}
