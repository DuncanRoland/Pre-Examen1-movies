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


    public Movie GetMovieByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));

        return Movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException();
    }
    
    public Movie GetMovieWithMostVisitors()
    {
        return Movies.OrderByDescending(m => m.VisitorCount).FirstOrDefault() ?? throw new InvalidOperationException();
    }

    public IEnumerable<Movie> GetMoviesByActor(Actor actor)
    {
        if (actor == null) throw new ArgumentNullException(nameof(actor));
        return Movies.Where(m => m.Actors.Contains(actor));
    }

    public IEnumerable<Movie> GetMoviesByDirector(Director director)
    {
        if (director == null) throw new ArgumentNullException(nameof(director));
        return Movies.Where(m => m.DirectorMovie == director);
    }

    public IEnumerable<Director> GetAllDirectors()
    {
        return Movies.Select(m => m.DirectorMovie).Distinct();
    }

    public IEnumerable<Movie> GetMoviesBetweenReleaseYear(int releaseYear, int year)
    {
        return Movies.Where(m => m.ReleaseDate.Year >= releaseYear && m.ReleaseDate.Year <= year);
    }

    public IEnumerable<Horror> GetHorrorMoviesWhereScareFactorIsGreaterThan(int scareFactor)
    {
        return Movies.OfType<Horror>().Where(h => h.ScareFactor > scareFactor);
    }

    public IEnumerable<Movie> GetUnreleasedMovies()
    {
        return Movies.Where(m => m.ReleaseDate > DateTime.Now);
    }
}   