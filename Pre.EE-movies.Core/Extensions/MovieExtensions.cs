using Pre.EE_movies.Core.Movies;
using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Extensions;

public static class MovieExtensions
{
    public static List<Animation> GetAnimationMovies(this IEnumerable<IMovie> movies)
        => movies.OfType<Animation>().ToList();

    public static List<Horror> GetHorrorMovies(this IEnumerable<IMovie> movies)
        => movies.OfType<Horror>().ToList();

}