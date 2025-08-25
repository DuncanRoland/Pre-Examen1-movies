using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Movie : IMovie, IComparable<Movie>
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; private set; }
    public int MinAge { get; set; }
    public Director DirectorMovie { get; }
    public List<Actor> Actors { get; }
    public int VisitorCount { get; set; }

    public Movie(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie)
    {
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        MinAge = minAge;
        DirectorMovie = directorMovie;
        Actors = new List<Actor>();
    }

    public int GetReleaseYear()
    {
        return ReleaseDate.Year;
    }

    public void AddActor(Actor actor)
    {
        if (!Actors.Contains(actor))
        {
            Actors.Add(actor);
        }
    }

    public void ReleaseMovie()
    {
        if (ReleaseDate <= DateTime.Now)
        {
            throw new Exception("The movie has already been released.");
        }

        ReleaseDate = DateTime.Now;
    }

    public void SetVisitorCount(int newVisitorCount)
    {
        if (newVisitorCount < 0)
        {
            throw new ArgumentException("Visitor count cannot be less than 0.");
        }

        if (newVisitorCount < VisitorCount)
        {
            throw new ArgumentException("Visitor count cannot be less than the previous visitor count.");
        }

        VisitorCount = newVisitorCount;
    }
    
    public void OnNewMovieAdded(object? sender, NewMovieEventArgs e)
    {
        Console.WriteLine($"{e.Cinema.CinemaName}: New movie: {e.Movie.Title} - {e.Movie.ReleaseDate.ToShortDateString()}!!!");
    }

    public int CompareTo(Movie? other)
    {
        if (other == null) return 1;
        return ReleaseDate.Year.CompareTo(other.ReleaseDate.Year);
    }

/*### Explanation

    - **Purpose**
        This method is used to compare the current `Movie` object with another `Movie` object. It is part of the implementation for the [`IComparable<T>` interface](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1), allowing movies to be ordered (for example, when sorting a list of movies).

    - **Parameters**
    - `Movie? other`: Another movie to compare with the current one. The `?` means `other` can be `null`.

    - **Logic**
    1. **Null Check**
    - `if (other == null) return 1;`
    - If `other` is `null`, the current movie is considered "greater" than a null value, so it returns `1`.

    2. **Compare Release Years**
    - `return ReleaseDate.Year.CompareTo(other.ReleaseDate.Year);`
    - Compares the release year of the current movie to the release year of the `other` movie:
    - Returns `-1` if the current movie was released **before** `other`
    - Returns `1` if released **after**
    - Returns `0` if they were both released in the **same year**

### Use Case

        This method enables you to sort or order a collection of `Movie` objects by their release years. For instance:
    - Movies from earlier years will come before movies from later years when sorted in ascending order.
    - If you tried to sort a list of `Movie` objects, this method determines their ordering.

### Summary

    - If `other` is `null`, current movie is considered greater.
    - Otherwise, movies are compared based on their release years.

        Let me know if you want more details, or an example of how this is used in code!*/
}