using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCrystal.Data;
using System;
using System.Linq;

namespace MvcCrystal.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcCrystalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcCrystalContext>>()))
        {
            if (context.Crystal.Any())
            {
                return;   // DB has been seeded
            }
            context.Crystal.AddRange(
                new Crystal
                {
                    Name = "Amethyst",
                    ExtractionDate = DateTime.Parse("1999-2-12"),
                    Color = "Purple",
                    Price = 7.99M
                },
                new Crystal
                {
                    Name = "Quartz",
                    ExtractionDate = DateTime.Parse("1996-5-6"),
                    Color = "Pink",
                    Price = 9.99M
                },
                new Crystal
                {
                    Name = "Obsidian",
                    ExtractionDate = DateTime.Parse("2002-2-2"),
                    Color = "Purple",
                    Price = 16.99M
                },
                new Crystal
                {
                    Name = "Jade",
                    ExtractionDate = DateTime.Parse("2021-4-12"),
                    Color = "Green",
                    Price = 6.99M
                }
            );
            context.SaveChanges();
        }
    }
}