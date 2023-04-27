using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCrystal.Models;

namespace MvcCrystal.Data
{
    public class MvcCrystalContext : DbContext
    {
        public MvcCrystalContext (DbContextOptions<MvcCrystalContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCrystal.Models.Crystal> Crystal { get; set; } = default!;

        public DbSet<MvcCrystal.Models.Cards> Cards { get; set; } = default!;

        public DbSet<MvcCrystal.Models.Candle> Candle { get; set; } = default!;

        public DbSet<MvcCrystal.Models.Employee> Employee { get; set; } = default!;
    }
}
