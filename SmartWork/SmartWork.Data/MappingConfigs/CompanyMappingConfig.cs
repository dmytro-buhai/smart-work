using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWork.Core.Entities;

namespace SmartWork.Data.MappingConfigs
{
    public class CompanyMappingConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.Address)
                .HasMaxLength(256)
                .IsRequired(true);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired(true);
            builder.Property(x => x.Description)
                .HasMaxLength(512)
                .IsRequired(false);
            builder.Property(x => x.PhotoFileName)
                .IsRequired(true);
        }
    }
}
