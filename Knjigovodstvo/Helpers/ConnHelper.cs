using System.Configuration;

namespace Knjigovodstvo
{
    class ConnHelper
    {
        public static string ConnStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
