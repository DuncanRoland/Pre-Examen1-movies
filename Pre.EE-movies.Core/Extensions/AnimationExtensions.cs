using Pre.EE_movies.Core.Enums;
using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Extensions;

public static class AnimationExtensions
{
    public static List<string> GetAllAnimationStudios(this IEnumerable<Animation> animations)
        => animations
            .Select(a => a.AnimationStudio)
            .Where(studio => !string.IsNullOrWhiteSpace(studio))
            .Distinct()
            .ToList();

    public static List<Animation> GetAllAnimationMoviesByAnimationType(this IEnumerable<Animation> animations, AnimationType type)
        => animations
            .Where(a => a.AnimationType == type)
            .ToList();
}