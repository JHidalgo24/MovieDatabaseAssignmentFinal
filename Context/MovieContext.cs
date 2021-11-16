using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetMovieSearch.DataModels;

namespace NetMovieSearch.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<MovieGenre> MovieGenres {get;set;}
        public DbSet<Occupation> Occupations {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserMovie> UserMovies {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Context//appsettings.json")
                .Build();            

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MovieContext"));
        }
    }
}