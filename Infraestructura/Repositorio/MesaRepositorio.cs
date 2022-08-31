using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class MesaRepositorio : IMesaRepositorio {
        private readonly ApplicationDbContext db;

        public MesaRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Mesa> actualizarMesa(Mesa mesa) {
            db.Update(mesa);
            await db.SaveChangesAsync();
            return mesa;
        }

        public async Task<Mesa> crearMesa(Mesa mesa) {
            await db.AddAsync(mesa);
            await db.SaveChangesAsync();
            return mesa;
        }

        public async Task<bool> eliminarMesa(int id) {
            try {
                Mesa mesa = await db.Mesa.FindAsync(id);
                if (mesa == null) {
                    return false;
                }
                db.Remove(mesa);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Mesa> obtenerMesa(int id) {
            return await db.Mesa.FindAsync(id);
        }

        public async Task<IReadOnlyList<Mesa>> obtenerMesas() {
            return await db.Mesa.ToListAsync();
        }
    }
}
