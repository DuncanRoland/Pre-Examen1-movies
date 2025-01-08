using Pre.EE_movies.DLL.Interfaces;

namespace Pre.EE_movies.Core.Movies;

public class Movies : Director , IMovie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; private set; }
    public int MinAge { get; set; }
    public Director DirectorMovie { get; }
    public List<Actor> Actors { get; }
    public int VisitorCount { get; set; }

    public Movies(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie)
    {
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        MinAge = minAge;
        DirectorMovie = directorMovie;
    }

    /*public int GetReleaseYear()
    {
        Console.WriteLine("test");
    }*/

    /*public AddActor(Actor actor)
    {
    }*/

    public void ReleaseMovie()
    {
        
    }
    
}