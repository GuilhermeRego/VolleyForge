using VolleyForge.Domain.Entities;

namespace VolleyForge.Tests;

public class ClubTests
{
    [Fact]
    public void CheckClubConstructor()
    {
        var club = new Club("Teste", "TST");

        Assert.NotEqual(Guid.Empty, club.Id);
        Assert.Equal("Teste", club.Name);
        Assert.Equal("TST", club.ShortName);
    }
}
