using System.Security.Cryptography;
using Pre.EE_movies.Core.Enums;

namespace Pre.EE_movies.Core.Movies;

public class Animation : Movie
{
    public string AnimationStudio { get; set; }
    public AnimationType AnimationType { get; set; }

    public Animation(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie,
        string animationStudio, AnimationType animationType) : base(title, genre, releaseDate, minAge, directorMovie)
    {
        AnimationStudio = animationStudio;
        AnimationType = animationType;
    }
}