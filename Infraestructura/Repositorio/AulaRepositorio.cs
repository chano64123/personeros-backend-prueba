using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class AulaRepositorio : IAulaRepositorio {
        private readonly ApplicationDbContext db;

        public AulaRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Aula> actualizarAula(Aula aula) {
            db.Update(aula);
            await db.SaveChangesAsync();
            return aula;
        }

        public async Task<Aula> crearAula(Aula aula) {
            await db.AddAsync(aula);
            await db.SaveChangesAsync();
            return aula;
        }

        public async Task<bool> eliminarAula(int id) {
            try {
                Aula aula = await db.Aula.FindAsync(id);
                if (aula == null) {
                    return false;
                }
                db.Remove(aula);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Aula> obtenerAula(int id) {
            return await db.Aula.FindAsync(id);
        }

        public async Task<IReadOnlyList<Aula>> obtenerAulas() {
            return await db.Aula.ToListAsync();
        }
    }
}
