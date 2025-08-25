using Pre.EE_movies.Core.Interfaces;
using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Services;

public class MovieService : Movie, IMovieService
{
    private List<Movie> Movies { get; }
    
    public MovieService(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, List<Movie> movies) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        Movies = movies;
    }

    public void AddMovie(Movie movie)
    {
        if (movie == null)
        {
            throw new ArgumentNullException(nameof(movie));
        }

        if (movie.ReleaseDate > DateTime.Now)
        {
            throw new InvalidOperationException("Movie must be released before adding.");
        }
        
        bool exists = Movies.Any(m =>
            m.Title == movie.Title &&
            m.ReleaseDate == movie.ReleaseDate &&
            m.DirectorMovie == movie.DirectorMovie &&
            m.Genre == movie.Genre);

        if (exists)
            throw new InvalidOperationException("Movie already exists in the list.");

        Movies.Add(movie);
        
    }
    

}