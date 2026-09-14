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
       if (name == string.Empty)
        {
            throw new ArgumentException("The name of the club shouldn't be empty.", nameof(name));
        }
        else if (shortName == string.Empty)
        {
            throw new ArgumentException("The shortname of the club shouldn't be empty.", nameof(shortName));
        }

        Id = Guid.NewGuid();
        Name = name;
        ShortName = shortName;
    }
}