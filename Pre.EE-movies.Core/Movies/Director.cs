using Pre.EE_movies.Core.Enums;
using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Director : Person
{
    private Random random { get; } = new();

    public Director(string name, DateTime birthdate) : base(name, birthdate)
    {
    }

    /*- **Title Extraction**:
    `string title = (movie as Movie)?.Title ?? "Unknown";`
        - Attempts to cast the object to the type . `movie``Movie`
    - If the cast is successful, retrieves the property. `Title`
    - If the cast fails or is `null`, uses the string as a fallback. `movie``"Unknown"`*/

    public override string WatchMovie(IMovie movie)
    {
        string title = (movie as Movie)?.Title ?? "Unknown";
        string message = $"Director {Name} is watching {title}";
        Console.WriteLine(message);
        return message;
    }

    public IMovie CreateNewMovie(string title, string genre, int minAge)
    {
        DateTime releaseDate = DateTime.Now; // or another value
        if (random.Next(2) == 0)
        {
            AnimationType animationType = AnimationType.ThreeD; // or random
            string animationStudio = "Default Studio"; // or random
            return new Animation(title, genre, releaseDate, minAge, this, animationStudio, animationType);
        }
        else
        {
            int scareFactor = random.Next(1, 11);
            return new Horror(title, genre, releaseDate, minAge, this, scareFactor);
        }
    }
}