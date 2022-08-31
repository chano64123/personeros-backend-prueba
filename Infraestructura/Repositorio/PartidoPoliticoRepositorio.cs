using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class PartidoPoliticoRepositorio : IPartidoPoliticoRepositorio {
        private readonly ApplicationDbContext db;

        public PartidoPoliticoRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<PartidoPolitico> actualizarPartidoPolitico(PartidoPolitico partidoPolitico) {
            db.Update(partidoPolitico);
            await db.SaveChangesAsync();
            return partidoPolitico;
        }

        public async Task<PartidoPolitico> crearPartidoPolitico(PartidoPolitico partidoPolitico) {
            await db.AddAsync(partidoPolitico);
            await db.SaveChangesAsync();
            return partidoPolitico;
        }

        public async Task<bool> eliminarPartidoPolitico(int id) {
            try {
                PartidoPolitico partidoPolitico = await db.PartidoPolitico.FindAsync(id);
                if (partidoPolitico == null) {
                    return false;
                }
                db.Remove(partidoPolitico);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<PartidoPolitico> obtenerPartidoPolitico(int id) {
            return await db.PartidoPolitico.FindAsync(id);
        }

        public async Task<IReadOnlyList<PartidoPolitico>> obtenerPartidosPoliticos() {
            return await db.PartidoPolitico.ToListAsync();
        }
    }
}
