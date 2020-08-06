using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace NetCoreConsoleExtensions
{
    public static class ConsoleParamReader
    {
        public static List<string> GetAssembly()
        {
            return  new List<string>();
        }

        public static T Read<T>(List<string> args, ILogger logger) where T : ConsoleParamBase
        {
            Type typeOfObject = typeof(T);
            T targetObject = (T)Activator.CreateInstance(typeOfObject, logger);

            var props = targetObject.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ConsoleParamAttribute)));

            foreach (var prop in props)
            {
                ConsoleParamAttribute attributeValue = (ConsoleParamAttribute)Attribute.GetCustomAttribute(prop, typeof(ConsoleParamAttribute));
                string argumentValue = args.FirstOrDefault(i => i.Contains(attributeValue.Name));
                if (!String.IsNullOrEmpty(argumentValue))
                {
                    prop.SetValue(targetObject, argumentValue.Replace($"-{attributeValue.Name}", ""));
                }
                else if (attributeValue.Required)
                {
                    throw new ConsoleParamException();
                }

            }
            return targetObject;
        }
    }
}
