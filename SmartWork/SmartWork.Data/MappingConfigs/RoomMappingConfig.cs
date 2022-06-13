using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class RoomMappingConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.Property(x => x.OfficeId)
                .IsRequired(true);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Number)
                .HasMaxLength(256)
                .IsRequired(false);
            builder.Property(x => x.Square)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.AmountOfWorkplaces)
                .HasMaxLength(1024)
                .IsRequired(true);
            builder.Property(x => x.PhotoFileName)
                .IsRequired(true);            
        }
    }
}
