using System.Net;
using System.Net.Http.Json;
using VolleyForge.Domain.Entities;
using VolleyForge.IntegrationTests.Fixtures;
using static VolleyForge.IntegrationTests.Fixtures.SharedFixture;

namespace VolleyForge.IntegrationTests.Database;

// This class belongs to the collection that has SharedFixture
[Collection(nameof(IntegrationTestCollection))]
public class DatabaseTests : IClassFixture<ApiFactory>
{
    private readonly ApiFactory _factory;

    public DatabaseTests(ApiFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    // Unit test to test our ApiFactory - which is overridden by our dbContainer with the test database
    [Fact(DisplayName = "Get all clubs returns all clubs")]
    public async Task GetAllClubsReturnsAllClubs()
    {
        // Arrange
        Club club1 = new("Associação Desportiva e Recreativa Escolar Praiense", "ADREP");
        Club club2 = new("Fayal Sport Club", "FSC");
        List<Club> clubs = [club1, club2];
        _factory._sharedFixture.VolleyForgeContext.AddRange(clubs);
        await _factory._sharedFixture.VolleyForgeContext.SaveChangesAsync();
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/clubs");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseClubs = await response.Content.ReadFromJsonAsync<List<Club>>();
        Assert.NotNull(responseClubs);
        Assert.NotEmpty(responseClubs);
        Assert.Equal(club1.Name, responseClubs[0].Name);
        Assert.Equal(club1.ShortName, responseClubs[0].ShortName);
        Assert.Equal(club2.Name, responseClubs[1].Name);
        Assert.Equal(club2.ShortName, responseClubs[1].ShortName);
    }
}
