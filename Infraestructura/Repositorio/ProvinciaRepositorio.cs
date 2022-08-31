using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class ProvinciaRepositorio : IProvinciaRepositorio {
        private readonly ApplicationDbContext db;

        public ProvinciaRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Provincia> actualizarProvincia(Provincia provincia) {
            db.Update(provincia);
            await db.SaveChangesAsync();
            return provincia;
        }

        public async Task<Provincia> crearProvincia(Provincia provincia) {
            await db.AddAsync(provincia);
            await db.SaveChangesAsync();
            return provincia;
        }

        public async Task<bool> eliminarProvincia(int id) {
            try {
                Provincia provincia = await db.Provincia.FindAsync(id);
                if (provincia == null) {
                    return false;
                }
                db.Remove(provincia);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Provincia> obtenerProvincia(int id) {
            return await db.Provincia.Include(p => p.departamento.pais).FirstOrDefaultAsync(p => p.idProvincia == id);
        }

        public async Task<IReadOnlyList<Provincia>> obtenerProvincias() {
            return await db.Provincia.Include(p => p.departamento.pais).ToListAsync();
        }
    }
}
