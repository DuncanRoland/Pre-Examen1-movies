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
        Director directorHorror = new Director("Stanley Kubrick", new DateTime(1980, 5, 16));

        // Test CreateNewMovie method
        var newMovie = director.CreateNewMovie(
            "Random Movie",
            "Adventure",
            10
        );


        // Existing code...
        Movie surfsUp = new Animation("SurfsUp", "Family, Animation", new DateTime(2006, 1, 1), 6, director, "Pixar",
            AnimationType.ThreeD);
        Movie inception = new Movie("Inception", "Sci-Fi", new DateTime(2010, 7, 16), 13, director);

        Movie fridayThe13Th = new Horror("fridayThe13th", "Horror", new DateTime(2010, 7, 16), 13, directorHorror, 7);

        inception.AddActor(new Actor("Guust Vermandere", new DateTime(1990, 3, 15)));
        // Display the created movie details
        DisplayMovieDetails((Movie)newMovie);
        DisplayMovieDetails(surfsUp);
        DisplayMovieDetails(inception);
        DisplayMovieDetails(fridayThe13Th);

        // Director watches movies
        director.WatchMovie(surfsUp);
        director.WatchMovie(inception);

        // Create an actor and have them watch movies
        Actor actor = new Actor("John Doe", new DateTime(1990, 3, 15));
        actor.WatchMovie(fridayThe13Th);

        // Add awards and watch another movie
        actor.AddAward(10);
        actor.WatchMovie(surfsUp);

        // Movie tests
        Console.WriteLine($"Release year Inception : {inception.GetReleaseYear()}");

        // Release a movie
        Movie tokyoDrift = new Movie("Tokyo Drift", "Action", DateTime.Now.AddDays(10), 10, director);
        Console.WriteLine($"Before release: {tokyoDrift.ReleaseDate}");
        tokyoDrift.ReleaseMovie();
        Console.WriteLine($"After release: {tokyoDrift.ReleaseDate}");

        // Visitor count tests
        tokyoDrift.SetVisitorCount(100);
        Console.WriteLine($"Visitor count: {tokyoDrift.VisitorCount}");
        tokyoDrift.SetVisitorCount(1000);
        Console.WriteLine($"Visitor count: {tokyoDrift.VisitorCount}");

        // Movie sort test
        List<Movie> movies = new List<Movie> { inception, surfsUp, fridayThe13Th, tokyoDrift };
        movies.Sort();
        Console.WriteLine("Movies sorted by release date:");
        foreach (var movie in movies)
        {
            Console.WriteLine($"{movie.Title} - {movie.ReleaseDate.ToShortDateString()}");
        }
    }

    private void DisplayMovieDetails(Movie movie)
    {
        Console.WriteLine(
            $"Movie: {movie.Title}, Genre: {movie.Genre}, Release Date: {movie.ReleaseDate.ToShortDateString()}, Min Age: {movie.MinAge}, Director: {movie.DirectorMovie.Name}, Actors: {string.Join(", ", movie.Actors.ConvertAll(a => a.Name))}");
    }
}