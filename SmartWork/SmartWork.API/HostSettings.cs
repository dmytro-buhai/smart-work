using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SmartWork.API.Properties.Resources;
using SmartWork.Configuration;
using SmartWork.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SmartWork.API
{
    public class HostSettings<T> where T : Startup
    {
        public static async Task SetBuildSettings(IHostBuilder hostBuilder)
        {
            Log.Logger = Helper.GetLogger();
            try
            {
                Log.Information(HostSettingsResources
                    .ResourceManager.GetString("LogApplicationStartInformation"));

                IHost host = hostBuilder.Build();

                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    try
                    {
                        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                        var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                        await RoleInitializer.InitializeAsync(userManager, rolesManager);
                        await Helper.SeedDataAsync(serviceProvider);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.Message, HostSettingsResources
                            .ResourceManager.GetString("LogSeedingDBError"));
                    }
                }
                
                host.Run();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception.Message, HostSettingsResources
                    .ResourceManager.GetString("LogApplicationFatal"));
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
