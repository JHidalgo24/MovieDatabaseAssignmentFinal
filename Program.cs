using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Channels;
using Microsoft.VisualBasic;
using NetMovieSearch.DataModels;
using NetMovieSearch.Context;

namespace NetMovieSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 1;
            int attemptsToBreak = 0;
            Console.WriteLine("1.)Search for Movies 2.)Remove Movie 3.) Update Movie 4.) Add new Movie 5)Search Movie By Year 6.)Exit");
            try
            {
                option = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry that is not an option you will now be defaulted to search");
                attemptsToBreak++;
                option = 1;
                if (attemptsToBreak > 3)
                {
                    Console.WriteLine("You will now be exited for having more than 3 failed inputs");
                    option = 5;
                }
            }
            
            
            
            while (option != 6)
            {
                if (option == 1)
                {
                    //prompt to read Movies
                    using (var db = new MovieContext())
                    {
                        var movies = db.Movies.ToList();
                        Console.WriteLine("What Movie do you want to look up (press enter for all)?");
                        string search = Console.ReadLine();
                        var moviesSearched = movies.Where(c => c.Title.ToLower().Contains(search.ToLower()));
                        if (moviesSearched.ToList().Count == 0)
                        {
                            Console.WriteLine("Sorry no films found");
                        }
                        else
                        {
                            foreach (var var in moviesSearched)
                            {
                                Console.WriteLine($"ID:{var.Id} Title:{var.Title} Year:{var.ReleaseDate}");
                            }
                        }
                        
            
                    }
                }

                else if (option == 2)
                {
                    //prompt to remove Movie
                    using (var db = new MovieContext())
                    {
                        var movies = db.Movies.ToList();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine($"ID:{movie.Id} Title:{movie.Title} Year:{movie.ReleaseDate}");
                        }
            
                        Console.WriteLine("What movie do you want to remove?");
                        string titletoRemove = Console.ReadLine();
                        var removedFilm = movies.FirstOrDefault(c=> c.Title.ToLower().Contains(titletoRemove.ToLower()));
                        Console.WriteLine(removedFilm);
                        if (removedFilm != null){
                            Console.WriteLine($"You are removing {removedFilm.Title} based on {titletoRemove} search");
                            db.Remove(removedFilm);
                            db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Sorry the film doesn't exists could not remove it\n");
                        }
                        
                    }
                }
                //prompt to uppdate Movie
                else if (option == 3)
                {
                    using (var db = new MovieContext())
                    {
                        var movies = db.Movies.ToList();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine($"ID:{movie.Id} Title:{movie.Title} Year:{movie.ReleaseDate}");
                        }
                     
                        Console.WriteLine("What movie do you want to replace: ");
                        string movieToReplace = Console.ReadLine();
                     
                        var movieReplace = movies.FirstOrDefault(c => c.Title.Contains(movieToReplace));
                        if (movieReplace == null)
                        {
                            Console.WriteLine($"Sorry {movieToReplace} is not a movie in the films that you could replace! ");
                        }
                        else
                        { 
                            Console.WriteLine($"This is the movie you are going to update {movieReplace.Title} {movieReplace.Id}");
                            Console.WriteLine("What is the title of the new movie?");
                            string newtitle = Console.ReadLine();
                            Console.WriteLine("What is the date of the movie?(M/D/YYYY)");
                            string userinput = Console.ReadLine();
                            DateTime result;
                            DateTime.TryParse(userinput, out result);
                            movieReplace.Title = newtitle;
                            movieReplace.ReleaseDate = result;
                            db.Movies.Update(movieReplace);
                            db.SaveChanges();
                        }
                    }
                }

                else if (option == 4)
                {
                    //prompt to add Movies
                    using (var db = new MovieContext())
                    {
                        Console.WriteLine("What is the title of the new Film: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("What is the date of the new movie?(M/D/yyyy)");
                        string date = Console.ReadLine();
                        DateTime resultDate = Convert.ToDateTime("1/1/1999"); 
                        DateTime.TryParse(date, out resultDate);
                        Movie add = new Movie();
                        add.Title = title;
                        add.ReleaseDate = resultDate;
        
                        db.Movies.Add(add);
                        db.SaveChanges();
                    }
                }
                else if(option == 5)
                {
                    int year = 0;
                    Console.WriteLine("What year do you want to look for in movies?(ex. 1995)");
                    try
                    {
                        year = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Sorry not a valid input");
                    }

                    using (var db = new MovieContext())
                    {
                       var moviesByDate = db.Movies.Where(movie => movie.ReleaseDate.Year == year);
                       
                       foreach (var var in moviesByDate)
                       {
                           Console.WriteLine($"Movie:{var.Title} ID:{var.Id} Date{var.ReleaseDate}");
                       }
                    }

                    
                }

                Console.WriteLine("1.)Search for Movies 2.)Remove Movie 3.) Update Movie 4.) Add new Movie 5)Search Movie By Years 6.)Exit");
                try
                {
                    option = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry that is not an option you will now be defaulted to search");
                    option = 1;
                    attemptsToBreak++;
                    if (attemptsToBreak > 3)
                    {
                        Console.WriteLine("You will now be exited for having more than 3 failed inputs");
                        option = 5;
                    }
                }
                
            }

            Console.WriteLine("Thank you for going through my Movies!");
        }
    }
}
