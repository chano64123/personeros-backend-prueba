using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class PaisRepositorio : IPaisRepositorio {
        private readonly ApplicationDbContext db;

        public PaisRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Pais> actualizarPais(Pais pais) {
            db.Update(pais);
            await db.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> crearPais(Pais pais) {
            await db.AddAsync(pais);
            await db.SaveChangesAsync();
            return pais;
        }

        public async Task<bool> eliminarPais(int id) {
            try {
                Pais pais = await db.Pais.FindAsync(id);
                if (pais == null) {
                    return false;
                }
                db.Remove(pais);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Pais> obtenerPais(int id) {
            return await db.Pais.FindAsync(id);
        }

        public async Task<IReadOnlyList<Pais>> obtenerPaises() {
            return await db.Pais.ToListAsync();
        }
    }
}
