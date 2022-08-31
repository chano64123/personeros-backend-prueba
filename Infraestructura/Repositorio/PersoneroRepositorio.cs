using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class PersoneroRepositorio : IPersoneroRepositorio {
        private readonly ApplicationDbContext db;

        public PersoneroRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Personero> actualizarPersonero(Personero personero) {
            db.Update(personero);
            await db.SaveChangesAsync();
            return personero;
        }

        public async Task<Personero> crearPersonero(Personero personero) {
            await db.AddAsync(personero);
            await db.SaveChangesAsync();
            return personero;
        }

        public async Task<bool> eliminarPersonero(int id) {
            try {
                Personero personero = await db.Personero.FindAsync(id);
                if (personero == null) {
                    return false;
                }
                db.Remove(personero);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Personero> obtenerPersonero(int id) {
            return await db.Personero.FindAsync(id);
        }

        public async Task<IReadOnlyList<Personero>> obtenerPersoneros() {
            return await db.Personero.ToListAsync();
        }
    }
}
