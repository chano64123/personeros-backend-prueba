using Microsoft.EntityFrameworkCore;
using Core.Model;

namespace Infraestructura.Datos {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        // aca van los dbset que se crearan como tabla en la base de datos
        public DbSet<Pais> Pais{ get; set; }
    }
}
