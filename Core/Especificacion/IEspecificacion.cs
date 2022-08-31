using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Especificacion {
    public interface IEspecificacion<TEntity> {
        Expression<Func<TEntity, bool>> Filtro { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
    }
}
