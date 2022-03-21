using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SmartWork.Configuration;
using System.Reflection;

namespace SmartWork.Data.AppContext
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        const string MIGRATIONS_HISTORY_TABLE_NAME = "Migrations";

        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = DBSettings.GetDBConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(connectionString,
                    o =>
                    {
                        o.MigrationsHistoryTable(MIGRATIONS_HISTORY_TABLE_NAME);
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    }).EnableSensitiveDataLogging();

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}