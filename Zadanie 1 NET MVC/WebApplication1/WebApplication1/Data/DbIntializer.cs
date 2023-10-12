using WebApplication1.Models;
using System;
using System.Linq;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Kontekst context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Klienci.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Klient[]
            {
            new Klient{Name="Jan",Surname="Kowalski",PESEL=123456789, BirthYear=2000, Plec=1},
            };
            foreach (Klient s in students)
            {
                context.Klienci.Add(s);
            }
            context.SaveChanges();
        }
    }
}