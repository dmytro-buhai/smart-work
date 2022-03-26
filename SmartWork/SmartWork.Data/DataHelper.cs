using Microsoft.Extensions.Configuration;
using SmartWork.Utils;
using System.IO;
using System.Text.RegularExpressions;

namespace SmartWork.Data
{
    internal class DataHelper
    {
        const string JSON_CONFIGURATION_FILE_NAME = "appsettings.json";
        const string CONFIGURATION_FILE_SOLUTION_RELATIVE_PATH = @"SmartWork.Configuration\AppSettings";
        const string PATH_TO_PASSWORD = @"C:\Users\Dmitriy\Desktop\Workspace\Univercity\SecureData\dbConnectionData.txt";

        private static IConfiguration GetConfiguration()
        {
            var configurationRootPath = GetConfigurationRootPath(CONFIGURATION_FILE_SOLUTION_RELATIVE_PATH);

            return new ConfigurationBuilder()
              .SetBasePath(configurationRootPath)
              .AddJsonFile(JSON_CONFIGURATION_FILE_NAME)
              .Build();
        }

        internal static string GetDBConnectionString()
        {
            var configuration = GetConfiguration();
            var dataBaseConnectionString = configuration.GetConnectionString("DataBaseConnection");
            GetSecurePasswordForDb(PATH_TO_PASSWORD, out string dbPassword);
            dataBaseConnectionString = dataBaseConnectionString.Replace("********", dbPassword);
            return dataBaseConnectionString;
        }

        private static void GetSecurePasswordForDb(string pathToPassword, out string dbPassword)
        {
            using var reader = new StreamReader(pathToPassword);
            dbPassword = reader.ReadToEnd();
            var regex = new Regex(@"^password=\[.+\]");
            var mathValue = regex.Match(dbPassword).Value;
            dbPassword = dbPassword[(dbPassword.IndexOf('[') + 1)..];
            dbPassword = dbPassword.Remove(dbPassword.LastIndexOf(']'));
        }

        private static string GetConfigurationRootPath(string relativePath)
        {
            var solutionPath = VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName;
            var configurationRootPath = Path.Combine(solutionPath, relativePath);
            return configurationRootPath;
        }
    }
}
