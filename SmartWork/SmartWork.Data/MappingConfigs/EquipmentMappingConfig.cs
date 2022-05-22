using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    class EquipmentMappingConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");

            builder.Property(x => x.RoomId)
                .IsRequired(true);
            builder.Property(x => x.Type)
                .IsRequired(true);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Description)
                .HasMaxLength(512)
                .IsRequired(false);
            builder.Property(x => x.Amount)
                .IsRequired(true);
            builder.Property(x => x.IsAvailable)
                .IsRequired(true);
        }
    }
}
