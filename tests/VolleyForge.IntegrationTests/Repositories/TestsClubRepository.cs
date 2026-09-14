using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.Domain.Entities;

namespace VolleyForge.IntegrationTests.Repositories;

public sealed class TestClubRepository : IClubRepository
{
    public Task<List<Club>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new List<Club>());
    }
        
    public Task<Club?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Club?>(null);
    }
}
