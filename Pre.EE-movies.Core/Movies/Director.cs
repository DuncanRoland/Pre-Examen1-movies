using Pre.EE_movies.Core.Enums;
using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Director : Person
{
    private Random random { get; } = new();

    public Director(string name, DateTime birthdate) : base(name, birthdate)
    {
    }

    public override string WatchMovie(IMovie movie)
    {
        throw new NotImplementedException();
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