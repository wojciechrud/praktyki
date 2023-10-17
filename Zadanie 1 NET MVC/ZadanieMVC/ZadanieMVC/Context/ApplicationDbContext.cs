using Microsoft.EntityFrameworkCore;
using System;
using ZadanieMVC.Models;

namespace ZadanieMVC.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        
        }

        public DbSet<Klient> Klienci { get; set; }
    }
}
