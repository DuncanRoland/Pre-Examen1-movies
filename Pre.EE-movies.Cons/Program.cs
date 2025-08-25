using Pre.EE_movies.Core.Movies;
using Pre.EE_movies.Core.Services;
using Pre.EE_movies.DLL.Interfaces;
using Animation = Pre.EE_movies.Core.Movies.Animation;
using AnimationType = Pre.EE_movies.Core.Enums.AnimationType;

namespace Pre.EE_movies.Cons;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        // Create a director
        Director director = new Director("Henk Deboer", new DateTime(2000, 1, 1));
        Director directorHorror = new Director("Stanley Kubrick", new DateTime(1980, 5, 16));

        // Test CreateNewMovie method
        IMovie newMovie = director.CreateNewMovie(
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
        foreach (Movie movie in movies)
        {
            Console.WriteLine($"{movie.Title} - {movie.ReleaseDate.ToShortDateString()}");
        }

        // Horror test
        Horror horrorMovie = new Horror("Scary Movie", "Horror", new DateTime(2020, 10, 31), 18, director, 8); // VALID
        //Horror horrorMovieInvalid = new Horror("Bad Example", "Horror", DateTime.Now, 18, director, 15); // THROWS EXCEPTION           
        Console.WriteLine($"Horror Movie: {horrorMovie.Title}, Scare Factor: {horrorMovie.ScareFactor}");
        // Console.WriteLine($"Horror Movie: {horrorMovieInvalid.Title}, Scare Factor: {horrorMovieInvalid.ScareFactor}");


        // Create unreleased movie
        Movie tripleX = new Movie("tripleX", "Action", DateTime.Now.AddDays(10), 10, director);

// Movieservice tests
        List<Movie> movieList = new List<Movie>();
        MovieService movieService = new MovieService("Service", "Service", DateTime.Now, 0, director, movieList);

// Add a released movie
        try
        {
            movieService.AddMovie(inception);
            Console.WriteLine("Inception added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add Inception: {ex.Message}");
        }

// Try to add the same movie again (should fail)
        try
        {
            movieService.AddMovie(inception);
            Console.WriteLine("Inception added again (unexpected).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Duplicate add failed as expected: {ex.Message}");
        }

// Try to add an unreleased movie (should fail)
        try
        {
            movieService.AddMovie(tripleX);
            Console.WriteLine("Tokyo Drift added (unexpected).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unreleased add failed as expected: {ex.Message}");
        }

// Now release the movie and continue with other tests
        Console.WriteLine($"Before release: {tripleX.ReleaseDate}");
        tripleX.ReleaseMovie();
        Console.WriteLine($"After release: {tripleX.ReleaseDate}");

        // Cinema tests

        // Create a MovieService instance
        List<Movie> cinemaMovies = new List<Movie> { inception, surfsUp, fridayThe13Th, tokyoDrift };
        MovieService cinemaMovieService =
            new MovieService("CinemaService", "Service", DateTime.Now, 1, director, cinemaMovies);

// Test Cinema constructor and SetCinemaName
        Cinema cinema = new Cinema("Kinepolis", cinemaMovieService);
        Console.WriteLine($"Initial Cinema Name: {cinema.CinemaName}");

        cinema.SetCinemaName("Cinefilm");
        Console.WriteLine($"Updated Cinema Name: {cinema.CinemaName}");

        // Test AddMovie with a new movie
        Movie newCinemaMovie = new Movie("Django", "Drama", DateTime.Now, 12, director);
        try
        {
            cinema.AddMovie(newCinemaMovie);
            Console.WriteLine($"{newCinemaMovie.Title} added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add New Cinema Movie: {ex.Message}");
        }
        
        // Test PlayMovie with an existing movie
        try
        {
            cinema.PlayMovie("Inception");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to play Inception: {ex.Message}");
        }
    }

    private void DisplayMovieDetails(Movie movie)
    {
        Console.WriteLine(
            $"Movie: {movie.Title}, Genre: {movie.Genre}, Release Date: {movie.ReleaseDate.ToShortDateString()}, Min Age: {movie.MinAge}, Director: {movie.DirectorMovie.Name}, Actors: {string.Join(", ", movie.Actors.ConvertAll(a => a.Name))}");
    }
}