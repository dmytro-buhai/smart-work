﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWork.BLL.Services;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using SmartWork.Data;
using SmartWork.Data.Repositories;
using SmartWork.Utils.ActionFilters;
using SmartWork.Utils.EntitiesUtils;

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

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // Register DbContext class
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(DBSettings.GetDBConnectionString()));

            // Register Repositories
            services.AddScoped<IUserRepository<User>, EFCoreUserRepository<User>>();
            services.AddScoped<IEntityRepository<Company>, EFCoreRepository<Company>>();
            services.AddScoped<IEntityRepository<Office>, EFCoreRepository<Office>>();
            services.AddScoped<IEntityRepository<Room>, EFCoreRepository<Room>>();

            // Register Entity Converters
            services.AddScoped<ICompanyEntityConverter, CompanyEntityConverter>();
            services.AddScoped<IOfficeEntityConverter, OfficeEntityConverter>();
            services.AddScoped<IRoomEntityConverter, RoomEntityConverter>();

            // Register General Services
            services.AddScoped<IGeneralEntityService<Company>, GeneralCompanyService>();
            services.AddScoped<IGeneralEntityService<Office>, GeneralOfficeService>();
            services.AddScoped<IGeneralEntityService<Room>, GeneralRoomService>();

            // Register Services
            services.AddScoped<ICompanyService, CompanyService>();           
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IRoomService, RoomService>();

            //Register Attributes
            services.AddScoped<ValidationFilterAttribute>();
        }
    }
}
