using Microsoft.Extensions.Configuration;

namespace SmartWork.Configuration
{
    public class DBSettings
    {
        const string PATH_TO_PASSWORD = @"C:\Users\Dmitriy\Desktop\Workspace\Univercity\SecureData\dbConnectionData.txt";
        public static string GetDBConnectionString()
        {
            var configuration = ConfigurationSettings.GetConfiguration();
            var dataBaseConnectionString = configuration.GetConnectionString("DataBaseConnection");
            Helper.GetSecurePasswordForDB(PATH_TO_PASSWORD, out string dbPassword);
            dataBaseConnectionString = dataBaseConnectionString.Replace("********", dbPassword);
            return dataBaseConnectionString;
        }
    }
}
