using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio {
        private readonly ApplicationDbContext db;

        public TipoUsuarioRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<TipoUsuario> actualizarTipoUsuario(TipoUsuario tipoUsuario) {
            db.Update(tipoUsuario);
            await db.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<TipoUsuario> crearTipoUsuario(TipoUsuario tipoUsuario) {
            await db.AddAsync(tipoUsuario);
            await db.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<bool> eliminarTipoUsuario(int id) {
            try {
                TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
                if (tipoUsuario == null) {
                    return false;
                }
                db.Remove(tipoUsuario);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<TipoUsuario> obtenerTipoUsuario(int id) {
            return await db.TipoUsuario.FindAsync(id);
        }

        public async Task<IReadOnlyList<TipoUsuario>> obtenerTiposUsuarios() {
            return await db.TipoUsuario.ToListAsync();
        }
    }
}
