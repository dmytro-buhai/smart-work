using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace SmartWork.Configuration
{
    public class DBSettings
    {
        public static string GetDBConnectionString()
        {
            var configuretion = ConfigurationSettings.GetConfiguration();
            var dataBaseConnectionString = configuretion.GetConnectionString("DataBaseConnection");
            var path = @"C:\Users\Dmitriy\Documents\SmartWork\dbConnectionData.txt";
            var dbPassword = string.Empty;
            using (var reader = new StreamReader(path))
            {
                dbPassword = reader.ReadToEnd();
                var regex = new Regex(@"^password=\[.+\]");
                var mathValue = regex.Match(dbPassword).Value;
                dbPassword = dbPassword[(dbPassword.IndexOf('[') + 1)..];
                dbPassword = dbPassword.Remove(dbPassword.LastIndexOf(']'));
            }
            dataBaseConnectionString = dataBaseConnectionString.Replace("********", dbPassword);
            return dataBaseConnectionString;
        }
    }
}
