using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using SmartWork.Configuration.Resources;
using SmartWork.Core.Entities;
using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    internal static class Helper
    {
        internal static string GetConfigurationRootPath(string relativePathToFileDirectory)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(Helper));
            var currentDirectory = Directory.GetCurrentDirectory();
            var solutionDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent;
            var configurationProjectDirectoryPath = Path.Combine(solutionDirectory.FullName, currentAssembly.GetName().Name);
            var configurationRootPath = Path.Combine(configurationProjectDirectoryPath, relativePathToFileDirectory);

            return configurationRootPath;
        }

        internal static string GetProjectName()
        {
            var currentAssembly = Assembly.GetAssembly(typeof(Helper));
            var projectName = currentAssembly.GetName().Name;
            return projectName;
        }

        internal static string GetConfigurationRootName()
        {
            var configurationRootName = HostSettingsResources.ResourceManager.GetString("AppSettings");
            return configurationRootName;
        }

        internal static string GetLogFilePath()
        {
            var logFilePath = HostSettingsResources.ResourceManager.GetString("LogFilePath");
            return logFilePath;
        }

        internal static string GetLogFileOutputTemplate()
        {
            var logFileOutputTemplate = HostSettingsResources.ResourceManager.GetString("FileOutputTemplate");
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

        internal static async Task InitializeRolesAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await RoleInitializer.InitializeAsync(userManager, rolesManager);
        }
    }
}
