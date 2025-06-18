using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder) {
        builder.ToTable("Educations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.School).HasMaxLength(200).IsRequired();

        builder.Property(x => x.Degree).HasMaxLength(100).IsRequired();

        builder.Property(x => x.FieldOfStudy).HasMaxLength(100).IsRequired();

        builder.Property(x => x.StartDate).IsRequired();

        builder.Property(x => x.EndDate);

        builder.HasOne(x => x.Resume).WithMany(x => x.Educations).HasForeignKey(x => x.ResumeId).OnDelete(DeleteBehavior.Cascade);
    }
}