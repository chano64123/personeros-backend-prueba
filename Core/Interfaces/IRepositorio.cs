using Core.Especificacion;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IRepositorio<TEntity> where TEntity: class{
        Task<IReadOnlyList<TEntity>> obtenerTodosAsync();
        Task<IReadOnlyList<TEntity>> obtenerTodosEspecificacionAsync(IEspecificacion<TEntity> especificacion);
        Task<TEntity> obtenerPorIdAsync(int id);
        Task<TEntity> obtenerPorIdEspecificoAsync(IEspecificacion<TEntity> especificacion);
        Task<TEntity> crearAsync(TEntity objeto);
        Task<TEntity> actualizarAsync(TEntity objeto);
        Task<bool> eliminarPorIdAsync(int id);
    }
}
