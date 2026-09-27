using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VolleyForge.Infrastructure.Persistence;

namespace VolleyForge.IntegrationTests.Fixtures;

public sealed class ApiFactory : WebApplicationFactory<Program>
{
    public SharedFixture _sharedFixture;

    public ApiFactory(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture ?? throw new ArgumentNullException(nameof(sharedFixture));
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Remove the real repository and point to the tests one
        // Because Program.cs runs before it reaches here and then we override its configurations
        builder.ConfigureServices(services =>
        {
            // Remove dbContextDescriptor
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<VolleyForgeContext>));
            services.Remove(dbContextDescriptor!);

            // Remove DbContext
            var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(VolleyForgeContext));
            services.Remove(dbContext!);

            // Add the container-based dbContext
            services.AddDbContext<VolleyForgeContext>(options => options.UseNpgsql(_sharedFixture.DatabaseConnectionString));
        });

        builder.UseEnvironment("Development");
    }
}
