using Core.Especificacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos {
    public class EvaluadorEspecificacion<TEntity> where TEntity : class {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, IEspecificacion<TEntity> especificacion) {
            var query = inputQuery;

            if (especificacion.Filtro != null) { 
                query = query.Where(especificacion.Filtro);
            }

            query = especificacion.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
