using Microsoft.EntityFrameworkCore;
using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.Domain.Entities;
using VolleyForge.Infrastructure.Persistence;

namespace VolleyForge.Infrastructure.Repositories;

public class ClubRepository(VolleyForgeContext context) : IClubRepository
{
    private readonly VolleyForgeContext _context = context;

    public async Task<List<Club>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Clubs
            .ToListAsync(cancellationToken);
    }

    public async Task<Club?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Clubs
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
