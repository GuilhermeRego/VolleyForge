using VolleyForge.Domain.Entities;

namespace VolleyForge.Tests.ClubTests;

public class ClubTests
{
    [Theory]
    [InlineData("TEST1", "TS1")]
    [InlineData("TEST2", "TS2")]
    public void Create_DataValid_ShouldCreate(string notEmptyName, string notEmptyShortName)
    {
        // Arrange
        var club = new Club(notEmptyName, notEmptyShortName);

        // Assert
        Assert.NotEqual(Guid.Empty, club.Id);
        Assert.NotEmpty(club.Name);
        Assert.NotEmpty(club.ShortName);
    }

    [Theory]
    [InlineData("", "TST")]
    [InlineData("TEST", "")]
    [InlineData("", "")]
    public void Create_NameIsEmpty_ShouldNotCreate(string name, string shortName)
    {
        // Arrange
        Action action = () => new Club(name, shortName);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}
