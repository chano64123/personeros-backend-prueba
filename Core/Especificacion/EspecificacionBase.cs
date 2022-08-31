using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Especificacion {
    public class EspecificacionBase<TEntity> : IEspecificacion<TEntity> {
        public EspecificacionBase(Expression<Func<TEntity, bool>> filtro) {
            Filtro = filtro;
        }
        public EspecificacionBase() {
        }

        public Expression<Func<TEntity, bool>> Filtro { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        protected void AgregarInclude(Expression<Func<TEntity, object>> includeExpression) {
            Includes.Add(includeExpression);
        }
    }
}
