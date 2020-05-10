using CovidInfoWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidInfoWebService.DataAccess
{
    public class InfoCovidDbContext : DbContext
    {
        
        public DbSet<CasoCovid> CasosCovid { get; set; }

        public InfoCovidDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Localizacion>(loc =>
            {
                loc.Property(l => l.LocalizacionId).ValueGeneratedOnAdd();
                loc.Property(l => l.Pais).IsRequired().HasMaxLength(128);
                loc.Property(l => l.Departamento).IsRequired().HasMaxLength(128);
                loc.Property(l => l.Municipio).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<CasoCovid>(caso =>
            {
                caso.Property(c => c.CasoCovidId).ValueGeneratedOnAdd();
                caso.HasOne(c => c.Localizacion);
                caso.Property(c => c.PrimerNombre).IsRequired().HasMaxLength(64);
                caso.Property(c => c.SegundoNombre).IsRequired().HasMaxLength(64);
                caso.Property(c => c.PrimerApellido).IsRequired().HasMaxLength(64);
                caso.Property(c => c.SegundoApellido).IsRequired().HasMaxLength(64);
                caso.Property(c => c.Edad).IsRequired();
                caso.Property(c => c.Sexo).IsRequired();
                caso.Property(c => c.Fecha).IsRequired();
            });

        }

    }
}
