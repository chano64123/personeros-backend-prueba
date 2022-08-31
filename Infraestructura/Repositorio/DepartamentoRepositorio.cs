using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class DepartamentoRepositorio : IDepartamentoRepositorio {
        private readonly ApplicationDbContext db;

        public DepartamentoRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Departamento> actualizarDepartamento(Departamento departamento) {
            db.Update(departamento);
            await db.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> crearDepartamento(Departamento departamento) {
            await db.AddAsync(departamento);
            await db.SaveChangesAsync();
            return departamento;
        }

        public async Task<bool> eliminarDepartamento(int id) {
            try {
                Departamento departamento = await db.Departamento.FindAsync(id);
                if (departamento == null) {
                    return false;
                }
                db.Remove(departamento);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Departamento> obtenerDepartamento(int id) {
            return await db.Departamento.Include(p => p.pais).FirstOrDefaultAsync(p => p.idPais == id);
        }

        public async Task<IReadOnlyList<Departamento>> obtenerDepartamentos() {
            return await db.Departamento.Include(p => p.pais).ToListAsync();
        }
    }
}
