using Microsoft.EntityFrameworkCore;
using StSluzba.Models;

namespace StSluzba.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Kursevi> Kursevi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kursevi>().HasData(
                new Kursevi { Id= 1, Naziv = "Racunarska grafika", Bodovi = 5},
                  new Kursevi { Id = 2, Naziv = "Multimedijalni sistemi", Bodovi = 5 },
                    new Kursevi { Id = 3, Naziv = "Osnove programiranja", Bodovi = 6 }
          );

        }
      
    }
}
