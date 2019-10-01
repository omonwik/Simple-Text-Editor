using System.Configuration;

namespace TextEditor.Infrastructure
{
    public static class ConfigurationHelper
    {
        public static string Get(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value ?? string.Empty;
        }
    }
}
