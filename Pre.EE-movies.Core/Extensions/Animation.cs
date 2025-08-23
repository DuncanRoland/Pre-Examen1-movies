using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Extensions;

public enum AnimationType
    {
        TwoD,
        ThreeD
    }
public class Animation : Movie
{
    public string AnimationStudio { get; set; }
    public AnimationType AnimationType { get; set; }
    
    public Animation(string title, string genre, DateTime releaseDate, int minAge, Director directorMovie, string animationStudio, AnimationType animationType)
        : base(title, genre, releaseDate, minAge, directorMovie)
    {
        AnimationStudio = animationStudio;
        AnimationType = animationType;
    }

    public void SetAnimationStudio(string animationStudio)
    {
        AnimationStudio = animationStudio;
    }
    
}