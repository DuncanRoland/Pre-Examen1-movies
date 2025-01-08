namespace Pre.EE_movies.Core.Movies;

public class Horror : Movie
{
    public int ScareFactor { get; set; }
    
    public Horror(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, int scareFactor) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        ScareFactor = scareFactor;
        
    }
    
}