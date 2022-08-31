using Microsoft.EntityFrameworkCore;
using Core.Model;
using System.Reflection;

namespace Infraestructura.Datos {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        // aca van los dbset que se crearan como tabla en la base de datos
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Institucion> Institucion { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PartidoPolitico> PartidoPolitico { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Personero> Personero { get; set; }
        public DbSet<ProcesoElectoral> ProcesoElectoral { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
