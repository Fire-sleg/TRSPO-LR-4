using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Emit;

namespace ProductAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            var guids = new List<Guid>()
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = guids[0],
                    Name = "Курячі яйця",
                    Description = "Description",
                    Kcal = 10
                },
                new Product
                {
                    Id = guids[1],
                    Name = "Картопля",
                    Description = "Description",
                    Kcal = 15
                },
                new Product
                {
                    Id = guids[2],
                    Name = "Цибуля",
                    Description = "Description",
                    Kcal = 25
                });


            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = "Яєчня",
                    Description = "Description",
                    ProductIds = new List<Guid>
                    {
                        guids[0],

                    }
                },
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = "Картопля з цибулею",
                    Description = "Description",
                    ProductIds = new List<Guid>
                    {
                        guids[1],
                        guids[2]

                    }
                },
                new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = "Картопля з яйцем та цибулею",
                    Description = "Description",
                    ProductIds = new List<Guid>
                    {
                        guids[0],
                        guids[1],
                        guids[2],

                    }
                });

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
    }
}
