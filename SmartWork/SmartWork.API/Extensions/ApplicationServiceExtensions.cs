using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWork.BLL.Services;
using SmartWork.BLL.Services.General;
using SmartWork.Configuration;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using SmartWork.Data;
using SmartWork.Data.Repositories;
using SmartWork.Utils.ActionFilters;
using SmartWork.Utils.EntitiesUtils;

namespace SmartWork.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
               IConfiguration config)
        {
            services.Configure<ApplicationSettings>(config.GetSection("ApplicationSettings"));

            // Enable CORS   
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            // Register DbContext class
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(DBSettings.GetDBConnectionString())
                        .UseSqlServer(o => o.UseQuerySplittingBehavior(
                            QuerySplittingBehavior.SplitQuery)));

            // Register Repositories
            services.AddScoped<IUserRepository<User>, EFCoreUserRepository<User>>();
            services.AddScoped<IEntityRepository<Company>, EFCoreRepository<Company>>();
            services.AddScoped<IEntityRepository<Office>, EFCoreRepository<Office>>();
            services.AddScoped<IEntityRepository<Room>, EFCoreRepository<Room>>();
            services.AddScoped<IEntityRepository<Equipment>, EFCoreRepository<Equipment>>();
            services.AddScoped<IEntityRepository<Statistic>, EFCoreRepository<Statistic>>();
            services.AddScoped<IEntityRepository<Subscribe>, EFCoreRepository<Subscribe>>();
            services.AddScoped<IEntityRepository<SubscribeDetail>, EFCoreRepository<SubscribeDetail>>();

            // Register Entity Converters
            services.AddScoped<ICompanyEntityConverter, CompanyEntityConverter>();
            services.AddScoped<IOfficeEntityConverter, OfficeEntityConverter>();
            services.AddScoped<IRoomEntityConverter, RoomEntityConverter>();
            services.AddScoped<IStatisticEntityConverter, StatisticEntityConverter>();

            // Register before another services
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<ISubscribeService, SubscribeService>();

            //// Register General Services
            //services.AddScoped<IGeneralEntityOperations<Company>, GeneralCompanyService>();
            //services.AddScoped<IGeneralEntityOperations<Office>, GeneralOfficeService>();
            //services.AddScoped<IGeneralEntityOperations<Room>, GeneralRoomService>();

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IRoomService, RoomService>();

            //Register Attributes
            services.AddScoped<ValidationFilterAttribute>();

            // JWT service
            services.AddScoped<JwtService>();

            services.AddAuthentication();

            return services;
        }
    }
}
