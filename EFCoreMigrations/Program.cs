using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMigrations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var db = new HTPContext();

            //db.Activities.AddRange(
            //    new Activity { Title = "Education" },
            //    new Activity { Title = "IT Consulting" },
            //    new Activity { Title = "Digital Marketing" },
            //    new Activity { Title = "Digital Art" },
            //    new Activity { Title = "FinTech" });

            //db.Residents.AddRange(
            //    new Resident { Title = "IT Academy" },
            //    new Resident { Title = "FinanceSoft" },
            //    new Resident { Title = "TimelySoft" });

            //await db.SaveChangesAsync();

            //var itAcademyActivities = new List<ResidentActivity> {
            //    new ResidentActivity { ResidentId = 1, ActivityId = 1 },
            //    new ResidentActivity { ResidentId = 1, ActivityId = 3 } };

            //var itAcademy =  await db.Residents.FirstAsync();

            //itAcademy.ResidentActivities = itAcademyActivities;

            //await db.SaveChangesAsync();

            var education = await db.Activities
                .Include(a => a.ResidentActivities)
                .ThenInclude(a => a.Resident)
                .FirstAsync();

            var educationProviders = education.ResidentActivities
                .Select(ra => ra.Resident);
        }
    }

    class HTPContext : DbContext
    {
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Activity> Activities { get; set; }
        //public DbSet<ResidentActivity> ResidentActivities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer(@"Server=AMANK-XPS-9360\SQLEXPRESS; Database=EFCoreMigrations; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ResidentActivity>()
                .HasKey(ra => new { ra.ResidentId, ra.ActivityId });

            builder.Entity<ResidentActivity>()
                .HasOne(ra => ra.Resident)
                .WithMany(r => r.ResidentActivities)
                .HasForeignKey(ra => ra.ResidentId);

            builder.Entity<ResidentActivity>()
                .HasOne(ra => ra.Activity)
                .WithMany(a => a.ResidentActivities)
                .HasForeignKey(ra => ra.ActivityId);
        }
    }

    class Resident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? EnteredDate { get; set; }
        //public ICollection<Activity> Activities { get; set; }
        public ICollection<ResidentActivity> ResidentActivities { get; set; }
    }

    class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public ICollection<Resident> Residents { get; set; }
        public ICollection<ResidentActivity> ResidentActivities { get; set; }
    }

    class ResidentActivity
    {
        public int ResidentId { get; set; }
        public int ActivityId { get; set; }

        public Resident Resident { get; set; }
        public Activity Activity { get; set; }
    }
}
