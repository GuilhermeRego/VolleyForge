using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.IntegrationTests.ApiTests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace VolleyForge.IntegrationTests.Fixtures;

public sealed class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Remove the real repository and point to the fake one to use as mock
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IClubRepository>();
            services.AddSingleton<IClubRepository, TestClubRepository>();
        });
    }
}
