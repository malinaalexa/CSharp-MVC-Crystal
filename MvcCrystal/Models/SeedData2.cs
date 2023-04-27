using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCrystal.Data;
using System;
using System.Linq;

namespace MvcCrystal.Models;

public static class SeedData2
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcCrystalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcCrystalContext>>()))
        {
            if (context.Cards.Any())
            {
                return;   // DB has been seeded
            }
            context.Cards.AddRange(
                new Cards
                {
                    Name = "Classic Playing Cards",
                    ReleaseDate = DateTime.Parse("2002-2-12"),
                    Designer = "Thomas Wheeler",
                    Price = 16.99M
                },
                new Cards
                {
                    Name = "Last Call Cats Playing Cards",
                    ReleaseDate = DateTime.Parse("2021-1-1"),
                    Designer = "Ravi Zupa",
                    Price = 50.99M
                },
                new Cards
                {
                    Name = "Rider-Waite Tarot Deck",
                    ReleaseDate = DateTime.Parse("2022-1-1"),
                    Designer = "Colman Smith Pamela",
                    Price = 54.99M
                },
                new Cards
                {
                    Name = "Rider-Waite Tarot Deck - Mini Edition",
                    ReleaseDate = DateTime.Parse("2023-1-1"),
                    Designer = "Colman Smith Pamela",
                    Price = 24.99M
                }
            );
            context.SaveChanges();
        }
    }
}