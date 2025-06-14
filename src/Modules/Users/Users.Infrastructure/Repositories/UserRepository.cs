using Microsoft.EntityFrameworkCore;
using Users.Domain.Abstractions;
using Users.Domain.Entities;
using Users.Infrastructure.Persistence;

namespace Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context) {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

    public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(User user) {
        if (user == null) {
            throw new ArgumentNullException(nameof(user));
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user) {
        if (user == null) {
            throw new ArgumentNullException(nameof(user));
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync() => await _context.Users.AsNoTracking().ToListAsync();
}