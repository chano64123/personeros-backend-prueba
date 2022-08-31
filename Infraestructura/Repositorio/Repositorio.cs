using Core.Especificacion;
using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio {
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class {
        private ApplicationDbContext db;

        public Repositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<TEntity> actualizarAsync(TEntity objeto) {
            db.Update(objeto);
            await db.SaveChangesAsync();
            return objeto;
        }

        public async Task<TEntity> crearAsync(TEntity objeto) {
            await db.AddAsync(objeto);
            await db.SaveChangesAsync();
            return objeto;
        }

        public async Task<bool> eliminarPorIdAsync(int id) {
            try {
                TEntity obj = await db.Set<TEntity>().FindAsync(id);
                if (obj == null) {
                    return false;
                }
                db.Remove(obj);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<IReadOnlyList<TEntity>> obtenerTodosAsync() {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> obtenerPorIdAsync(int id) {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> obtenerTodosEspecificacionAsync(IEspecificacion<TEntity> especificacion) {
            return await aplicarEspecificacion(especificacion).ToListAsync();
        }

        public async Task<TEntity> obtenerPorIdEspecificoAsync(IEspecificacion<TEntity> especificacion) {
            return await aplicarEspecificacion(especificacion).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> aplicarEspecificacion(IEspecificacion<TEntity> especificacion) {
            return EvaluadorEspecificacion<TEntity>.GetQuery(db.Set<TEntity>().AsQueryable(), especificacion);

        }
    }
}
