using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Extensions;

public class Horror : Movie
{
    public int ScareFactor { get; set; }
    
    public Horror(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, int scareFactor) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        this.ScareFactor = scareFactor;
    }

    public void SetScareFactor(int scareFactor)
    {
        ScareFactor = scareFactor;
    }
    
}