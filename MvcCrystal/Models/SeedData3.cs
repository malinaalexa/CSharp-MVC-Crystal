using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCrystal.Data;
using System;
using System.Linq;

namespace MvcCrystal.Models;

public static class SeedData3
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcCrystalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcCrystalContext>>()))
        {
            if (context.Candle.Any())
            {
                return;   // DB has been seeded
            }
            context.Candle.AddRange(
                new Candle
                {
                    Name = "Basic small candle",
                    ExpirationDate = DateTime.Parse("2024-2-12"),
                    Color = "White",
                    Price = 1.99M
                },
                new Candle
                {
                    Name = "Basic big candle",
                    ExpirationDate = DateTime.Parse("2024-2-1"),
                    Color = "White",
                    Price = 6.99M
                },
                new Candle
                {
                    Name = "Heart-shaped candle",
                    ExpirationDate = DateTime.Parse("2024-2-1"),
                    Color = "Red",
                    Price = 17.99M
                },
                new Candle
                {
                    Name = "Rose-shaped candle",
                    ExpirationDate = DateTime.Parse("2025-3-5"),
                    Color = "Pink",
                    Price = 15.99M
                }
            );
            context.SaveChanges();
        }
    }
}