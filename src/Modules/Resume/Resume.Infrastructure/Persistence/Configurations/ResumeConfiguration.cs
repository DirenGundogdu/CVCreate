using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resume.Infrastructure.Persistence.Configurations;

public class ResumeConfiguration : IEntityTypeConfiguration<Domain.Entities.Resume>
{

    public void Configure(EntityTypeBuilder<Domain.Entities.Resume> builder) { 
        builder.ToTable("Resumes");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.UserId).IsRequired();

        builder.Property(x => x.Title).HasMaxLength(200).IsRequired();

        builder.Property(x => x.Summary).HasMaxLength(1000).IsRequired();

        builder.Property(x => x.CreatedAt).IsRequired();

        builder.Property(x => x.UpdatedAt).IsRequired();

        builder.HasMany(x => x.Experiences).WithOne().HasForeignKey(x => x.ResumeId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Educations).WithOne().HasForeignKey(x => x.ResumeId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Skills).WithOne().HasForeignKey("ResumeId").OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Languages).WithOne().HasForeignKey("ResumeId").OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.References).WithOne().HasForeignKey(x => x.ResumeId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Links).WithOne().HasForeignKey("ResumeId").OnDelete(DeleteBehavior.Cascade);
    }
}