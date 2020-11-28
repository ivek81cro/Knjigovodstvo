using System.Configuration;

namespace Knjigovodstvo
{
    class ConnHelper
    {
        /// <summary>
        /// Gets connection string from config file.
        /// </summary>
        /// <param name="name">Name of connection string in config file</param>
        /// <returns>String</returns>
        public static string ConnStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
