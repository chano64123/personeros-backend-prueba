using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class DistritoRepositorio : IDistritoRepositorio {
        private readonly ApplicationDbContext db;

        public DistritoRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Distrito> actualizarDistrito(Distrito distrito) {
            db.Update(distrito);
            await db.SaveChangesAsync();
            return distrito;
        }

        public async Task<Distrito> crearDistrito(Distrito distrito) {
            await db.AddAsync(distrito);
            await db.SaveChangesAsync();
            return distrito;
        }

        public async Task<bool> eliminarDistrito(int id) {
            try {
                Distrito distrito = await db.Distrito.FindAsync(id);
                if (distrito == null) {
                    return false;
                }
                db.Remove(distrito);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Distrito> obtenerDistrito(int id) {
            return await db.Distrito.FindAsync(id);
        }

        public async Task<IReadOnlyList<Distrito>> obtenerDistritos() {
            return await db.Distrito.ToListAsync();
        }
    }
}
