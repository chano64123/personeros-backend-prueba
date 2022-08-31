using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class UsuarioRepositorio : IUsuarioRepositorio {
        private readonly ApplicationDbContext db;

        public UsuarioRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Usuario> actualizarUsuario(Usuario usuario) {
            db.Update(usuario);
            await db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> crearUsuario(Usuario usuario) {
            await db.AddAsync(usuario);
            await db.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> eliminarUsuario(int id) {
            try {
                Usuario usuario = await db.Usuario.FindAsync(id);
                if (usuario == null) {
                    return false;
                }
                db.Remove(usuario);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Usuario> obtenerUsuario(int id) {
            return await db.Usuario.FindAsync(id);
        }

        public async Task<IReadOnlyList<Usuario>> obtenerUsuarios() {
            return await db.Usuario.ToListAsync();
        }
    }
}
