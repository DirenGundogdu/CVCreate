using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class ReferenceConfiguration : IEntityTypeConfiguration<Reference>
{
    public void Configure(EntityTypeBuilder<Reference> builder) {
        builder.ToTable("References");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);

        builder.Property(x => x.Position).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Company).IsRequired().HasMaxLength(150);

        builder.Property(x => x.Email).HasMaxLength(100);

        builder.Property(x => x.Phone).HasMaxLength(20);
    }
}