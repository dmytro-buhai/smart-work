using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class SubscribeDetailsMappingConfig : IEntityTypeConfiguration<SubscribeDetail>
    {
        public void Configure(EntityTypeBuilder<SubscribeDetail> builder)
        {
            builder.ToTable("SubscribeDetails");
            
            builder.Property(x => x.RoomId)
                .IsRequired(true);
            builder.Property(x => x.Type)
                .IsRequired(true);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Price)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Description)
                .HasMaxLength(128)
                .IsRequired(false);
        }
    }
}
