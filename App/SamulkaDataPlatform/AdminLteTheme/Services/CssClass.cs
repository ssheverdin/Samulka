using System;
using System.Collections.Generic;
using System.Text;

namespace AdminLteTheme.Services
{
    public class CssClass
    {
        private string _cssClassValue { get; set; }

        public CssClass()
        {
            _cssClassValue = "";
        }

        public string Add(string cssClass)
        {
            if (!string.IsNullOrEmpty(cssClass))
            {
                _cssClassValue =
                string.IsNullOrEmpty(_cssClassValue) ?
                string.Concat(_cssClassValue, cssClass) :
                string.Concat(_cssClassValue, " ", cssClass);
            }
            return _cssClassValue;
        }
        public void Add(string cssClass, bool condition)
        {
            _cssClassValue = condition ? Add(cssClass) : _cssClassValue;
        }

        public string Build()
        {
            return _cssClassValue;
        }
    }
}
