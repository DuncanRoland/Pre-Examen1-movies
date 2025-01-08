using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Director : Person
{
    private Random random { get; }

    public Director(string name, DateTime birthdate) : base(name, birthdate)
    {
    }

    public override string WatchMovie(IMovie movie)
    {
        throw new NotImplementedException();
    }
}