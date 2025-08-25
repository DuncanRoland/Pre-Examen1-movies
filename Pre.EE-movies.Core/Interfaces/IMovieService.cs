using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Interfaces;

public interface IMovieService
{
    // use Linq
    Movie GetMovieByTitle(string title);

    public Movie GetMovieWithMostVisitors();
    
    IEnumerable<Movie> GetMoviesByActor(Actor actor);
    IEnumerable<Movie> GetMoviesByDirector(Director director);
    IEnumerable<Director> GetAllDirectors();
    IEnumerable<Movie> GetMoviesBetweenReleaseYear(int releaseYear, int year);
    IEnumerable<Horror> GetHorrorMoviesWhereScareFactorIsGreaterThan(int scareFactor);
    IEnumerable<Movie> GetUnreleasedMovies();
}