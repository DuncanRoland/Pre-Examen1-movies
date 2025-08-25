using Pre.EE_movies.Core.Movies;
using Pre.EE_movies.Core.Services;

namespace Pre.EE_movies.Cons;

public class CinemaAsyncTestProgram
{
    public static async Task Main()
    {
        // Provide required arguments for MovieService constructor
        var director = new Director("Test Director", DateTime.Now);
        var movieList = new List<Movie>();
        var movieService = new MovieService("ServiceName", "Location", DateTime.Now, 0, director, movieList);

        var cinema = new Cinema("TestCinema", movieService);

        // Use a valid path and format ("json" or "csv")
        var movies = await cinema.LoadMoviesAsync("movies.json", "json");

        Console.WriteLine($"Loaded {movies.Count} movies.");
        foreach (var movie in movies)
        {
            // If IMovie does not have Title, cast to Movie
            Console.WriteLine((movie as Movie)?.Title ?? "Unknown Title");
        }
    }
}