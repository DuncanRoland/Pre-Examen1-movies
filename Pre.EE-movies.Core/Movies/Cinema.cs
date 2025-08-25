using Pre.EE_movies.Core.Services;
using Pre.EE_movies.DLL.Interfaces;
using Pre.EE_movies.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Cinema : ICinema
{
    public string CinemaName { get; set; }
    private MovieService MovieService { get; }
    private Random _random;

    // Event for giving awards
    public event EventHandler<Movie> GiveAwardEvent;
    public event EventHandler<NewMovieEventArgs> NewMovieEvent;


    public Cinema(string cinemaName, MovieService movieService)
    {
        CinemaName = cinemaName;
        MovieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        _random = new Random();
    }

    // Explicit setter as required by UML
    public void SetCinemaName(string name)
    {
        CinemaName = name;
    }

    public void AddMovie(IMovie movie)
    {
        MovieService.AddMovie((Movie)movie);
        OnNewMovieEvent((Movie)movie);
    }
    
    protected virtual void OnNewMovieEvent(Movie movie)
    {
        NewMovieEvent?.Invoke(this, new NewMovieEventArgs(movie, this));
    }

    public List<IMovie> LoadMoviesAsync(string path, string format)
    {
        throw new NotImplementedException();
    }


    public void PlayMovie(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));

        // Find the movie by title using MovieService
        var movie = MovieService.GetMovieByTitle(title);
        if (movie == null)
            throw new InvalidOperationException("Movie not found.");

        if (movie.ReleaseDate > DateTime.Now)
            throw new InvalidOperationException("Movie has not been released yet.");

        int visitors = _random.Next(1, 101);
        movie.VisitorCount += visitors;

        var actors = string.Join(", ", movie.Actors.Select(a => a.Name));
        Console.WriteLine(
            $"{movie.Title} - {movie.DirectorMovie.Name}: Actors: {actors} - Number of visitors: {movie.VisitorCount}");

        // Trigger GiveAwardEvent if visitors > 250
        if (movie.VisitorCount > 250)
        {
            OnGiveAwardEvent(movie);
        }
    }

    protected virtual void OnGiveAwardEvent(Movie movie)
    {
        // Give each actor an award first
        foreach (Actor actor in movie.Actors)
        {
            actor.AddAward(1);
        }

        // Then raise the event so the handler sees the updated count
        GiveAwardEvent?.Invoke(this, movie);
    }
}