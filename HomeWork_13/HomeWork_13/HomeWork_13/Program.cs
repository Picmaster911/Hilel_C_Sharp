// See https://aka.ms/new-console-template for more information
using HomeWork_13;

var movies = new MovieLibrary();
Console.WriteLine(movies[11]);
Console.WriteLine("----------------");
foreach (var movie in movies)
{
    Console.WriteLine(movie);
}
Console.WriteLine("----------------");
movies[11] = "NEW FILM";
Console.WriteLine(movies[11]);
