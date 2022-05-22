using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class OfficeMappingConfig : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");

            builder.Property(x => x.CompanyId)
                .IsRequired(true);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Address)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(12)
                .IsRequired(true);
            builder.Property(x => x.IsFavourite)
                .IsRequired(true);
            builder.Property(x => x.PhotoFileName)
                .IsRequired(true);            
        }
    }
}
