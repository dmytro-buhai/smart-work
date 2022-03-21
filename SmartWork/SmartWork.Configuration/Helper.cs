﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using SmartWork.Configuration.Resources;
using SmartWork.Core.Entities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    internal static class Helper
    {
        internal static string GetConfigurationRootPath(string relativePath)
        {
            var solutionPath = VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName;
            var configurationRootPath = Path.Combine(solutionPath, relativePath);
            return configurationRootPath;
        }
        
        internal static void GetSecurePasswordForDb(string pathToPassword, out string dbPassword)
        {
            using var reader = new StreamReader(pathToPassword);
            dbPassword = reader.ReadToEnd();
            var regex = new Regex(@"^password=\[.+\]");
            var mathValue = regex.Match(dbPassword).Value;
            dbPassword = dbPassword[(dbPassword.IndexOf('[') + 1)..];
            dbPassword = dbPassword.Remove(dbPassword.LastIndexOf(']'));
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