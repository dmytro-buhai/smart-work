using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class StatisticMappingConfig : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.ToTable("Statistics");

            builder.Property(x => x.RoomId)
                .IsRequired(true);
            builder.Property(x => x.Type)
                .IsRequired(true);
            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Description)
                .HasMaxLength(512)
                .IsRequired(false);
            builder.Property(x => x.Data)
                .IsRequired(true);
        }
    }
}
