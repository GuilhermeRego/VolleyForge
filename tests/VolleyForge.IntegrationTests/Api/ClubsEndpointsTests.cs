using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.Domain.Entities;
using VolleyForge.IntegrationTests.Fixtures;

namespace VolleyForge.IntegrationTests.ApiTests;

public class ClubsEndpointsTests : IClassFixture<ApiWebApplicationFactory>
{
    private readonly ApiWebApplicationFactory _factory;

    public ClubsEndpointsTests(ApiWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/api/clubs")]
    public async Task Get_EndpointsReturnSuccess(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }
}
