using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Interstellar",
                    ReleaseDate = DateTime.Parse("2014-11-7"),
                    Genre = "SciFi",
                    Rating = "PG13",
                    Price = 9.99M
                },
new Movie
{
    Title = "Inception",
    ReleaseDate = DateTime.Parse("2010-7-16"),
    Genre = "SciFi",
    Rating = "PG13",
    Price = 8.99M
},
new Movie
{
    Title = "The Batman",
    ReleaseDate = DateTime.Parse("2022-3-4"),
    Genre = "Action",
    Rating = "PG13",
    Price = 10.99M
}

            );
            context.SaveChanges();
        }
    }
}