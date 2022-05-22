using Microsoft.Extensions.Configuration;
using System.IO;

namespace SmartWork.Configuration
{
    public class ConfigurationSettings
    {
        const string JSON_CONFIGURATION_FILE_NAME = "appsettings.json";
        const string CONFIGURATION_FILE_SOLUTION_RELATIVE_PATH = @"SmartWork.Configuration\AppSettings";

        public static IConfiguration GetConfiguration()
        {
            var configurationRootPath = Helper.GetConfigurationRootPath(CONFIGURATION_FILE_SOLUTION_RELATIVE_PATH);

            return new ConfigurationBuilder()
              .SetBasePath(configurationRootPath)
              .AddJsonFile(JSON_CONFIGURATION_FILE_NAME)
              .Build();
        }
    }
}
