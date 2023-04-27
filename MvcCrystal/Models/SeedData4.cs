using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCrystal.Data;
using System;
using System.Linq;

namespace MvcCrystal.Models;

public static class SeedData4
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcCrystalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcCrystalContext>>()))
        {
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }
            context.Employee.AddRange(
                new Employee
                {
                    Name = "Ethan Nguyen",
                    HireDate = DateTime.Parse("2023-2-3"),
                    Position = "Sales Associate",
                    Salary = 35000M
                },
                new Employee
                {
                    Name = "Olivia Patel",
                    HireDate = DateTime.Parse("2023-2-7"),
                    Position = "Store Manager",
                    Salary = 60000M
                },
                new Employee
                {
                    Name = "Tyler Kim",
                    HireDate = DateTime.Parse("2022-3-8"),
                    Position = "Marketing Coordinator",
                    Salary = 45000M
                },
                new Employee
                {
                    Name = "Ava Ramirez",
                    HireDate = DateTime.Parse("2022-4-2"),
                    Position = "Inventory Manager",
                    Salary = 50000M
                }
            );
            context.SaveChanges();
        }
    }
}