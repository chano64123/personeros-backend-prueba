using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class ProcesoElectoralRepositorio : IProcesoElectoralRepositorio {
        private readonly ApplicationDbContext db;

        public ProcesoElectoralRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<ProcesoElectoral> actualizarProcesoElectoral(ProcesoElectoral procesoElectoral) {
            db.Update(procesoElectoral);
            await db.SaveChangesAsync();
            return procesoElectoral;
        }

        public async Task<ProcesoElectoral> crearProcesoElectoral(ProcesoElectoral procesoElectoral) {
            await db.AddAsync(procesoElectoral);
            await db.SaveChangesAsync();
            return procesoElectoral;
        }

        public async Task<bool> eliminarProcesoElectoral(int id) {
            try {
                ProcesoElectoral procesoElectoral = await db.ProcesoElectoral.FindAsync(id);
                if (procesoElectoral == null) {
                    return false;
                }
                db.Remove(procesoElectoral);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<ProcesoElectoral> obtenerProcesoElectoral(int id) {
            return await db.ProcesoElectoral.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProcesoElectoral>> obtenerProcesosElectorales() {
            return await db.ProcesoElectoral.ToListAsync();
        }
    }
}
