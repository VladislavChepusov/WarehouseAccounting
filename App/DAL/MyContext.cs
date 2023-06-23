using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

using App.DAL.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace App.DAL
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

            string connectionString = configuration["ConnectionString"];
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Box> Boxes => Set<Box>();
        public DbSet<Pallet> Pallets => Set<Pallet>();
    }
}
