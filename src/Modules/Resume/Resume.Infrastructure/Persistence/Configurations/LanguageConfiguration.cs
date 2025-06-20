using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder) {
        builder.ToTable("Languages");

        builder.HasKey(x => new { x.ResumeId, x.Name, x.Proficiency });

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

        builder.Property(x => x.Proficiency).HasMaxLength(100).IsRequired();
    }
}