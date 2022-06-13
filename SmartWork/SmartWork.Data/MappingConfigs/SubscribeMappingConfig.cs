using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class SubscribeMappingConfig : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.ToTable("Subscribes");

            builder.Property(x => x.RoomId)
                .IsRequired(true);
            builder.Property(x => x.UserId)
                .IsRequired(true);
            builder.Property(x => x.StartDate)
                .IsRequired(true);
            builder.Property(x => x.EndDate)
                .IsRequired(true); 
        }
    }
}
