using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreInheritance
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var db = new AppDbContext();

            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            /*
             * SEED DATA
            var dogBreeds = new List<DogBreed>
            {
                new DogBreed { Title = "Ovcharka" },
                new DogBreed { Title = "Alabai" },
                new DogBreed { Title = "Husky" },
                new DogBreed { Title = "Bulldog" }
            };

            var catBreeds = new List<CatBreed>
            {
                new CatBreed { Title = "MaineCoon" },
                new CatBreed { Title = "Persian" },
                new CatBreed { Title = "Siamese" }
            };

            db.DogBreeds.AddRange(dogBreeds);
            db.CatBreeds.AddRange(catBreeds);

            db.Dogs.Add(new Dog
            {
                BirthDate = new DateTime(2018, 1, 1),
                DogBreed = dogBreeds[2],
                Petname = "Hatiko"
            });

            db.Cats.AddRange(
                new Cat
                {
                    BirthDate = new DateTime(2020, 1, 1),
                    CatBreed = catBreeds[1],
                    Petname = "Foo"
                },
                new Cat
                {
                    BirthDate = new DateTime(2019, 3, 4),
                    CatBreed = catBreeds[0],
                    Petname = "Maine Coon"
                });

            await db.SaveChangesAsync();
            */

            var animals = await db.Animals.AsNoTracking().ToListAsync();

            // Eager loading
            var cats = await db.Cats.Include(c => c.CatBreed).AsNoTracking().ToListAsync();

            cats[0].CatBreed.Title = "Bad cat";

            // Explicit loading
            var dogs = await db.Dogs.ToListAsync();

            await db.Entry(dogs[0]).Reference(d => d.DogBreed).LoadAsync();

            dogs[0].DogBreed.Title = "Husky";

            await db.SaveChangesAsync();

            var dogBreeds = await db.DogBreeds.ToListAsync();
        }
    }

    class AppDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
        public DbSet<CatBreed> CatBreeds { get; set; }
        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder
            .UseLoggerFactory(ConsoleLoggerFactory)
            .UseSqlServer(@"Server=AMANK-XPS-9360\SQLEXPRESS; Database=EFCoreInheritance; Integrated Security=true");
    }

    class Animal
    {
        public int Id { get; set; }
        public string Petname { get; set; }
        public DateTime BirthDate { get; set; }
    }

    class Dog : Animal
    {
        public int DogBreedId { get; set; }
        public DogBreed DogBreed { get; set; }
    }

    class Cat : Animal
    {
        public int CatBreedId { get; set; }
        public CatBreed CatBreed { get; set; }
    }

    class DogBreed
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    class CatBreed
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
