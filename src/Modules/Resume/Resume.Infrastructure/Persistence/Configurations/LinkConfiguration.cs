using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder) {
        builder.ToTable("Links");

        builder.HasKey(x => new { x.ResumeId, x.Url, x.Title });

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.Url).HasMaxLength(300).IsRequired();

        builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
    }
}