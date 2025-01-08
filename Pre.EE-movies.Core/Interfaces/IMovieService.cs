using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Core.Interfaces;

public interface IMovieService
{
    // use Linq
    public Movie GetMovieByTitle(string title)
    {
        return 
    }
    
    public Movie GetMovieWithMostVisitors()
    {
        throw new NotImplementedException();
    } 
    
    public IEnumerable<Movie> GetMoviesByActor(Actor actor)
    {
        throw new NotImplementedException();
    }  
    
    public IEnumerable<Movie> GetMoviesByDirector(Director director)
    {
        throw new NotImplementedException();
    }  
    
    public IEnumerable<Director> GetAllDirectors()
    {
        throw new NotImplementedException();
    } 
    
    public IEnumerable<Movie> GetMoviesBetweenReleaseYear(int releaseYear, int year)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Horror> GetHorrorMoviesWhereScareFactorIsGreaterThan(int scareFactor)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Movie> GetUnreleasedMovies()
    {
        throw new NotImplementedException();
    }
    
}