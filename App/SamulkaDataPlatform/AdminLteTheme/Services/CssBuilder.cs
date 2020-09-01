using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminLteTheme.Services
{
    public static class CssBuilder 
    {
        public static CssClass CssClass()
        {
            return new CssClass();
        }

        public static CssClass AddClass(this CssClass cssClassValue, string cssClass)
        {
            cssClassValue.Add(cssClass);
            return cssClassValue;
        }

        public static CssClass AddClass(this CssClass cssClassValue, string cssClass, bool condition)
        {
            cssClassValue.Add(cssClass, condition);
            return cssClassValue;
        }

        public static CssClass AddClass(this CssClass cssClassValue, Dictionary<string,object> attributes)
        {
            if(attributes != null)
            {
                if (attributes.ContainsKey("class"))
                {
                    cssClassValue.Add(attributes["class"].ToString());
                }
            }
            return cssClassValue;
        }
    }
}
