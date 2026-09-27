using System.Net;
using VolleyForge.IntegrationTests.Fixtures;
using static VolleyForge.IntegrationTests.Fixtures.SharedFixture;

namespace VolleyForge.IntegrationTests.Api;

[Collection(nameof(IntegrationTestCollection))]
public class EndpointsTests : IClassFixture<ApiFactory>
{
    private readonly ApiFactory _factory;

    public EndpointsTests(ApiFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    [Theory(DisplayName = "Get all clubs returns OK")]
    [InlineData("/api/clubs")]
    public async Task Get_EndpointsReturnsOK(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
