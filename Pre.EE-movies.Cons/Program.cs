using Pre.EE_movies.Core.Enums;
using Pre.EE_movies.Core.Movies;
using Pre.EE_movies.Core.Services;

namespace Pre.EE_movies.Cons;

class Program
{
    static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
        // Create a director
        Director director = new Director("Henk Deboer", new DateTime(2000, 1, 1));

        // Test CreateNewMovie method
        var newMovie = director.CreateNewMovie(
            "Random Movie",
            "Adventure",
            10
        );

        // Display the created movie details
        DisplayMovieDetails((Movie)newMovie);

        // Existing code...
        Movie surfsUp = new Animation("SurfsUp", "Family, Animation", new DateTime(2006, 1, 1), 6, director, "Pixar", AnimationType.ThreeD);
        Movie inception = new Movie("Inception", "Sci-Fi", new DateTime(2010, 7, 16), 13, director);
        Director directorHorror = new Director("Stanley Kubrick", new DateTime(1980, 5, 16));
        Movie fridayThe13Th = new Horror("fridayThe13th", "Horror", new DateTime(2010, 7, 16), 13, directorHorror, 7 );

        DisplayMovieDetails(surfsUp);
        DisplayMovieDetails(inception);
        DisplayMovieDetails(fridayThe13Th);
    }

    private void DisplayMovieDetails(Movie movie)
    {
        Console.WriteLine($"Movie: {movie.Title}, Genre: {movie.Genre}, Release Date: {movie.ReleaseDate.ToShortDateString()}, Min Age: {movie.MinAge}, Director: {movie.DirectorMovie.Name}");
    }
}