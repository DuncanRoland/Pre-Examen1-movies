namespace Pre.EE_movies.Core.Movies;

public class NewMovieEventArgs : EventArgs
{
    public Movie Movie { get; }
    public Cinema Cinema { get; }

    public NewMovieEventArgs(Movie movie, Cinema cinema)
    {
        Movie = movie;
        Cinema = cinema;
    }
}