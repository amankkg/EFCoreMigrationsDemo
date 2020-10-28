using System;
using System.Linq;

namespace EFCoreReverseEngineering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var db = new EFCoreReverseEngineeringContext();

            //db.Residents.Add(new Residents { Title = "IT Academy", Activity = "Education", Entered = DateTime.Now });

            //db.SaveChanges();

            var residents = db.Residents.ToList();
        }
    }
}
