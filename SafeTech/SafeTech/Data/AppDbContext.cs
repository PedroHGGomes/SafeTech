using Microsoft.EntityFrameworkCore;
using SafeTech.Models;

namespace SafeTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ABRIGO> ABRIGOS { get; set; }
        public DbSet<SENSOR> SENSORES { get; set; }
        public DbSet<LEITURA_SENSOR> LEITURAS_SENSOR { get; set; }
        public DbSet<ALERTA> ALERTAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ABRIGO>().ToTable("ABRIGO");
            modelBuilder.Entity<SENSOR>().ToTable("SENSOR");
            modelBuilder.Entity<LEITURA_SENSOR>().ToTable("LEITURA_SENSOR");
            modelBuilder.Entity<ALERTA>().ToTable("ALERTA");
        }
    }
}
