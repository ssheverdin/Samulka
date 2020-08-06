using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreConsoleExtensions
{
    public abstract class ConsoleParamBase
    {
        protected readonly ILogger _logger;

        protected ConsoleParamBase(ILogger logger)
        {
            _logger = logger;
        }

        public bool Validate()
        {
            try
            {
                _logger.LogInformation($"Parameters of {this.GetType().Name}: ");
                foreach (var attributeInfo in GetAttributes())
                {
                    Console.WriteLine($"{attributeInfo.Key}: {attributeInfo.Value}");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ConsoleParamException("Parameters are not valid");
            }
        }

        public Dictionary<string, string> GetAttributes()
        {
            var result = new Dictionary<string, string>();

            var props = this.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ConsoleParamAttribute)));

            foreach (var prop in props)
            {
                ConsoleParamAttribute attributeValue = (ConsoleParamAttribute)Attribute.GetCustomAttribute(prop, typeof(ConsoleParamAttribute));
                result.Add(attributeValue.Name, $"{prop.Name}{(attributeValue.Required ? " (Required)" : "")} - {prop.GetValue(this)}");
            }
            return result;
        }

    }
}
