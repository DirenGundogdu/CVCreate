namespace Resume.Domain.Abstractions;

public interface IResumeRepository
{
    Task<Entities.Resume?> GetByIdAsync(Guid id);
    Task<List<Entities.Resume>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Entities.Resume resume);
    Task UpdateAsync(Entities.Resume resume);
    Task DeleteAsync(Entities.Resume resume);
}