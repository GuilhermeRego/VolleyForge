namespace VolleyForge.Domain.Entities;

public sealed class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ShortName { get; private set; }

    private Club()
    {
        Name = string.Empty;
        ShortName = string.Empty;
    }

    public Club(string name, string shortName)
    {
        Id = Guid.NewGuid();
        Name = name;
        ShortName = shortName;
    }
}