namespace Pre.EE_movies.Core.Movies;

public class PlayMovieEventArgs : EventArgs
{
    public string MovieName { get; }
    public DateTime StartTime { get; }

    public PlayMovieEventArgs(string movieName, DateTime startTime)
    {
        MovieName = movieName;
        StartTime = startTime;
    }
}