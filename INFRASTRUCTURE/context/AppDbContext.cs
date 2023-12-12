using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.Entities;
using System.Diagnostics.Contracts;
using DOMAIN;
 
namespace INFRASTRUCTURE
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions dbcontext) : base(dbcontext)
        {
            
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JHQE1L6\\SQLEXPRESS; User Id =sa;Password=123456; Database=BibioDb;TrustServerCertificate=True");
        }


        //declaer les tables
        public DbSet<ouvrage> ouvrages { get; set; }
        public DbSet<Adherant> adherants { get; set; }
        public DbSet<emprunt> emprunter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //mapping relation many to many via class emprunt   using EF
            modelBuilder.Entity<Adherant>()
                .HasMany(e => e.ouvrages)
                .WithMany(e => e.adherants)
                .UsingEntity<emprunt>();
                  
        }



    }
}
