using Microsoft.EntityFrameworkCore;
using Resume.Domain.Abstractions;
using Resume.Infrastructure.Persistence;

namespace Resume.Infrastructure.Repositories;

public class ResumeRepository : IResumeRepository
{
    private readonly ResumeDbContext _context;

    public ResumeRepository(ResumeDbContext context) {
        _context = context;
    }

    public async Task<Domain.Entities.Resume?> GetByIdAsync(Guid id) => await _context.Resumes
        .Include(x => x.Experiences)
        .Include(x => x.Educations)
        .Include(x => x.Skills)
        .Include(x => x.Languages)
        .Include(x => x.References)
        .Include(x => x.Links)
        .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Domain.Entities.Resume?> GetByUserIdAsync(Guid userId) => await _context.Resumes
        .Include(x => x.Experiences)
        .Include(x => x.Educations)
        .Include(x => x.Skills)
        .Include(x => x.Languages)
        .Include(x => x.References)
        .Include(x => x.Links)
        .AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);

    public async Task AddAsync(Domain.Entities.Resume resume)  {
        if(resume == null) {
            throw new ArgumentNullException(nameof(resume));
        }
        await _context.Resumes.AddAsync(resume);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Domain.Entities.Resume resume) {
        if(resume == null) {
            throw new ArgumentNullException(nameof(resume));
        }
        _context.Update(resume);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Entities.Resume resume) {
        if (resume == null) {
            throw new ArgumentNullException(nameof(resume));
        }
        _context.Resumes.Remove(resume);
        await _context.SaveChangesAsync();
    }
}