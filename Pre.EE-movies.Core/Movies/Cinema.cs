using Pre.EE_movies.Core.Services;
using Pre.EE_movies.DLL.Interfaces;
using Pre.EE_movies.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Cinema : ICinema
{
    private string CinemaName { get; set; }
    private MovieService MovieService { get; }
    private Random _random;

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
    

    public List<IMovie> LoadMoviesAsync(string path, string format)
    {
        throw new NotImplementedException();
    }

    public void AddMovie(IMovie movie)
    {
        throw new NotImplementedException();
    }

    public void PlayMovie(string title)
    {
        throw new NotImplementedException();
    }
}