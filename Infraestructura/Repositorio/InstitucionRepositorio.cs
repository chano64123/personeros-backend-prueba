using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class InstitucionRepositorio : IInstitucionRepositorio {
        private readonly ApplicationDbContext db;

        public InstitucionRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Institucion> actualizarInstitucion(Institucion institucion) {
            db.Update(institucion);
            await db.SaveChangesAsync();
            return institucion;
        }

        public async Task<Institucion> crearInstitucion(Institucion institucion) {
            await db.AddAsync(institucion);
            await db.SaveChangesAsync();
            return institucion;
        }

        public async Task<bool> eliminarInstitucion(int id) {
            try {
                Institucion institucion = await db.Institucion.FindAsync(id);
                if (institucion == null) {
                    return false;
                }
                db.Remove(institucion);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Institucion> obtenerInstitucion(int id) {
            return await db.Institucion.FindAsync(id);
        }

        public async Task<IReadOnlyList<Institucion>> obtenerInstituciones() {
            return await db.Institucion.ToListAsync();
        }
    }
}
