using Microsoft.EntityFrameworkCore;
using VolleyForge.Domain.Entities;

namespace VolleyForge.Infrastructure.Persistence;

public class VolleyForgeContext(DbContextOptions<VolleyForgeContext> options) : DbContext(options)
{
    // Maps Configuration to the respective Entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VolleyForgeContext).Assembly);
    }

    public DbSet<Club> Clubs { get; set; }
}
