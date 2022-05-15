using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWork.BLL.Services;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Abstractions.Services.Base;
using SmartWork.Core.Entities;
using SmartWork.Data;
using SmartWork.Data.Repositories;
using SmartWork.Utils.ActionFilters;
using SmartWork.Utils.Validators;

namespace SmartWork.Configuration
{
    public class DependencyResolver
    {
        public IConfiguration Configuration { get; }

        public DependencyResolver(IServiceCollection services)
        {
            Configuration = ConfigurationSettings.GetConfiguration();
            ConfigureServices(services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // Register DbContext class
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(DBSettings.GetDBConnectionString()));

            // Register Repositories
            services.AddScoped<IUserRepository<User>, EFCoreUserRepository<User>>();
            services.AddScoped<IEntityRepository<Company>, EFCoreRepository<Company>>();

            // Register Services
            services.AddTransient<IEntityService<Company>, GeneralCompanyService>();
            services.AddTransient<ICompanyService, CompanyService>();

            //Register Attributes
            services.AddScoped<ValidationFilterAttribute>();
        }
    }
}
