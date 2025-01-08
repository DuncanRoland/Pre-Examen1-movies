using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Actor : Person
{
    public int AwardsCount { get; }

    public Actor(string name, DateTime birthdate) : base(name, birthdate)
    {
    }

    public int AddAward(int award ) => AwardsCount + award;

    public override string WatchMovie(IMovie movie)
    {
        throw new NotImplementedException();
    }
}