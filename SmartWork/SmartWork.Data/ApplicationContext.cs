using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartWork.Core.Entities;

namespace SmartWork.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<SubscribeDetail> SubscribeDetail { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
    }
}
