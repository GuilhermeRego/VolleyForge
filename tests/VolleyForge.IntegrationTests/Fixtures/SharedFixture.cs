using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;
using VolleyForge.Infrastructure.Persistence;

namespace VolleyForge.IntegrationTests.Fixtures;

public sealed class SharedFixture : IAsyncLifetime
{
    private VolleyForgeContext? _dbContext;

    public VolleyForgeContext VolleyForgeContext => _dbContext ?? throw new InvalidOperationException("The database context has not been initialized.");

    // Create a postgres:18 container
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder("postgres:18").Build();

    public string DatabaseConnectionString => _dbContainer.GetConnectionString();

    [CollectionDefinition(nameof(IntegrationTestCollection))]
    public class IntegrationTestCollection : ICollectionFixture<SharedFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place
        // to apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }

    // Start PostgreSql test container
    public async Task InitializeAsync()
    {
        // _dbContainer starts here
        await _dbContainer.StartAsync();

        // Same as Program.cs for the real database with EF Core
        var optionsBuilder = new DbContextOptionsBuilder<VolleyForgeContext>()
            .UseNpgsql(DatabaseConnectionString);

        _dbContext = new VolleyForgeContext(optionsBuilder.Options);

        // Migration
        await _dbContext.Database.MigrateAsync();
    }

    // Delete instance
    public async Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
        await _dbContext!.DisposeAsync();
    }
}
