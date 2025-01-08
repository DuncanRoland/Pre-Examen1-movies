using Pre.EE_movies.Core.Enums;
using Pre.EE_movies.Core.Movies;

namespace Pre.EE_movies.Cons;

class Program
{
    static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
       // Make move

       Movie SurfsUp = new Animation("SurfsUp", "Family", new DateTime(2006, 1, 1), 6,
           new Director("Henk Deboer", new DateTime(2000, 1, 1)), "Pixar", AnimationType.ThreeD);

       Console.WriteLine($"Movie: {SurfsUp.Title}, Genre: {SurfsUp.Genre}, Releasedate: {SurfsUp.ReleaseDate},\n Director: {SurfsUp.DirectorMovie.Name}");
    }
}
