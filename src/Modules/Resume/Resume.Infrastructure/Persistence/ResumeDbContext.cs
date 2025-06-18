using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.Entities;

namespace Resume.Infrastructure.Persistence;

public class ResumeDbContext(DbContextOptions<ResumeDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Entities.Resume> Resumes => Set<Domain.Entities.Resume>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Link> Links => Set<Link>();
    public DbSet<Reference> References => Set<Reference>();
    public DbSet<Skill> Skills => Set<Skill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}