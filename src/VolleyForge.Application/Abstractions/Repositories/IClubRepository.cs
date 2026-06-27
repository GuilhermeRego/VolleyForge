using VolleyForge.Domain.Entities;

namespace VolleyForge.Application.Abstractions.Repositories;

public interface IClubRepository
{
    Task<IReadOnlyList<Club>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Club?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
