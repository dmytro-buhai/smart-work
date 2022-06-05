using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using SmartWork.Configuration.Resources;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Utils;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    public static class Helper
    {
        internal static string GetConfigurationRootPath(string relativePath)
        {
            var solutionPath = VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName;
            var configurationRootPath = Path.Combine(solutionPath, relativePath);
            return configurationRootPath;
        }
        
        public static void GetSecurePasswordForDB(string pathToPassword, out string dbPassword)
        {
            using var reader = new StreamReader(pathToPassword);
            dbPassword = reader.ReadToEnd();
            var regex = new Regex(@"^password=\[.+\]");
            var mathValue = regex.Match(dbPassword).Value;
            dbPassword = dbPassword[(dbPassword.IndexOf('[') + 1)..];
            dbPassword = dbPassword.Remove(dbPassword.LastIndexOf(']'));
        }

        public static ILogger GetLogger()
        {
            return CreateLogger();
        }

        internal static string GetLogFilePath()
        {
            var logFilePath = LogResources.ResourceManager.GetString("LogRelativeFilePath");
            return logFilePath;
        }

        internal static string GetLogFileOutputTemplate()
        {
            var logFileOutputTemplate = LogResources.ResourceManager.GetString("FileOutputTemplate");
            return logFileOutputTemplate;
        }

        internal static ILogger CreateLogger()
        {
            var logFilePath = GetLogFilePath();
            var fileOutputTemplate = GetLogFileOutputTemplate();
            var configuration = ConfigurationSettings.GetConfiguration();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(logFilePath, restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: fileOutputTemplate)
                .CreateLogger();
        }

        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var companyService = serviceProvider.GetRequiredService<ICompanyService>();
            var officeService = serviceProvider.GetRequiredService<IOfficeService>();
            var roomService = serviceProvider.GetRequiredService<IRoomService>();
            var seed = new Seed(companyService, officeService, roomService);
            await seed.SeedData();
        }
    }
}
