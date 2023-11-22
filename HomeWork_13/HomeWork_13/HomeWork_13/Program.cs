using HomeWork_13;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

Dictionary<int, string> _ordinaryMovies = new Dictionary<int, string>()
        {
           { 100, "THE MARVELS" },
           { 101, "THE KILLER" },
           { 102, "FIVE NIGHTS AT FREDDY'S" },
           { 103, "KILLERS OF THE FLOWER MOON" },
           { 104, "THE HOLDOVERS"},
           { 105, "DUMB MONEY" },
           { 106,"NYAD" }
        };
Dictionary<int, string> _onlyAdultMovies = new Dictionary<int, string>()
        {
           { 107, "XXX" },
           { 108, "PRISCILLA" },
           { 109, "A HAUNTING IN VENICE " },
           { 110,"WHEN EVIL LURKS" },
           { 111,"QUIZ LADY" }
        };

using (var myDB = new AppDbContext())
{
    void AddToDb(Dictionary<int, string> movies, bool forAdult)
    {
        foreach (KeyValuePair<int, string> movie in movies)
        {
            myDB.Movies.Add(new Movie
            {
                Key = movie.Key,
                Name = movie.Value,
                ForAdult = forAdult
            });
        }
    }
    AddToDb(_ordinaryMovies, false);
    AddToDb(_onlyAdultMovies, true);
    myDB.SaveChanges();

    var ordinaryMovies = new Dictionary<int, string>();
    var onlyAdultMovies = new Dictionary<int, string>();

    var allMovies = myDB.Movies;

    foreach (var movie in allMovies)
    {
        if (movie.ForAdult)
        {
            onlyAdultMovies.Add(movie.Key, movie.Name);
        }
        if (!movie.ForAdult)
        {
            ordinaryMovies.Add(movie.Key, movie.Name);
        }
    }

    var libraryMovies = new MovieLibrary(ordinaryMovies, onlyAdultMovies);

    foreach (var library in libraryMovies)
    {
        Console.WriteLine(library);
    }
    var movieDell = myDB.Movies.Where(m => m.Name == "NYAD").FirstOrDefault();

    if (movieDell != null)
    {
        myDB.Movies.Remove(movieDell);
        myDB.SaveChanges();
    }

    var movieForUpdate = myDB.Movies.Where(x => x.Name == "XXX").FirstOrDefault();

    if (movieForUpdate != null)
    {
        movieForUpdate.Name = "New XXX";
        myDB.SaveChanges();
    }

    allMovies = myDB.Movies;

}
