using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder) {
        builder.ToTable("Skills");

        builder.HasKey(x=> new { x.ResumeId, x.Name, x.Level});

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Level).IsRequired().HasMaxLength(50);
    }
}