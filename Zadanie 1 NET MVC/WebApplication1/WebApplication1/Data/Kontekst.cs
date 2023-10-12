using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class Kontekst: DbContext
    {
        public Kontekst(DbContextOptions<Kontekst> options) : base(options)
        {

        }
        public DbSet<Klient> Klienci { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>().ToTable("Klient");
        }
    }
}