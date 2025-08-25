using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Extensions;

public class Horror : Movie
{
    
    private int _scareFactor;

    public int ScareFactor
    {
        get => _scareFactor;
        set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(ScareFactor), "ScareFactor must be between 0 and 10.");
            }
            _scareFactor = value;
        }
    }

    
    public Horror(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, int scareFactor) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        ScareFactor = scareFactor;
        
    }
    
    
}