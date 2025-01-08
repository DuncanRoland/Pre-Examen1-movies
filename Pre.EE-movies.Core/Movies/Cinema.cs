using Pre.EE_movies.Core.Services;
using Pre.EE_movies.DLL.Interfaces;
using Pre.EE_movies.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Cinema : ICinema
{
    public string CinemaName { get; set; }

    private MovieService _movieService { get; }

    private Random random;

    public Cinema(string cinemaName)
    {
        CinemaName = cinemaName;
    }

    public List<IMovie> LoadMoviesAsync(string path, string format)
    {
        throw new NotImplementedException();
        //return
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