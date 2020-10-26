using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class HTPContext : DbContext
    {
        public DbSet<Resident> Residents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=AMANK-XPS-9360\SQLEXPRESS; Database=EFCoreMigrations; Integrated Security=true");
        }
    }

    class Resident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Activity { get; set; }
        public DateTime? Entered { get; set; }
    }
}
