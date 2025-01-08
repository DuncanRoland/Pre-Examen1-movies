using Pre.EE_movies.Core.Interfaces;
using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Services;

public class MovieService : Movie, IMovieService
{
    private List<Movie> movies { get; }
    
    public MovieService(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, List<Movie> movies) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        this.movies = movies;
    }

    public void AddMovie(Movie movie) => movies.Add(movie);

}