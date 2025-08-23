using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Movie : IMovie
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
}