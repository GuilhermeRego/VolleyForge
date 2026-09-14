using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using VolleyForge.Application.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VolleyForge.IntegrationTests.Repositories;

namespace VolleyForge.IntegrationTests.Fixtures;

public sealed class ApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Remove the real repository and point to the fake one to use as mock
        // Because Program.cs runs before it reaches here
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IClubRepository>();
            services.AddSingleton<IClubRepository, TestClubRepository>();
        });

        builder.UseEnvironment("Development");
    }
}
