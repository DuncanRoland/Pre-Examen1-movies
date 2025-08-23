using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Actor : Person
{
    public int AwardsCount { get; private set; }

    public Actor(string name, DateTime birthdate) : base(name, birthdate)
    {
        AwardsCount = 0;
    }

    public int AddAward(int award ) => AwardsCount + award;

    public override string WatchMovie(IMovie movie)
    {
        string title = (movie as Movie)?.Title ?? "Unknown";
        string message = $"Actor {Name} is watching {title} and he/she has {AwardsCount} awards";
        Console.WriteLine(message);
        return message;
    }
}