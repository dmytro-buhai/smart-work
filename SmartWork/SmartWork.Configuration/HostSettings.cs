using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Serilog;
using SmartWork.Configuration.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SmartWork.Configuration
{
    public class HostSettings<T> where T : class
    {
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).UseSerilog();
        
        public static async Task SetBuildSettings(string[] args)
        {
            Log.Logger = Helper.CreateLogger();
            try
            {
                Log.Information(HostSettingsResources.ResourceManager.GetString("LogApplicationStartInformation"));
                var hostBuilder = CreateHostBuilder(args);
                IHost host = hostBuilder.Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        await Helper.InitializeRolesAsync(services);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.Message, HostSettingsResources.ResourceManager.GetString("LogSeedingDBError"));
                    }
                }
                
                host.Run();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception.Message, HostSettingsResources.ResourceManager.GetString("LogApplicationFatal"));
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
