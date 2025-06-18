using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder) {
        builder.ToTable("Experiences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ResumeId).IsRequired();

        builder.Property(x => x.Company).HasMaxLength(200).IsRequired();

        builder.Property(x => x.Position).HasMaxLength(150).IsRequired();

        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();

        builder.Property(x => x.StartDate).IsRequired();

        builder.Property(x => x.EndDate);

        builder.HasOne(x => x.Resume).WithMany(x => x.Experiences).HasForeignKey(x => x.ResumeId).OnDelete(DeleteBehavior.Cascade);
    }
}