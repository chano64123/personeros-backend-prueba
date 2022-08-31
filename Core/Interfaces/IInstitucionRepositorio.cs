using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IInstitucionRepositorio {
        //los metodos que tendra en repositorio
        Task<Institucion> crearInstitucion(Institucion institucion);
        Task<IReadOnlyList<Institucion>> obtenerInstituciones();
        Task<Institucion> obtenerInstitucion(int id);
        Task<Institucion> actualizarInstitucion(Institucion institucion);
        Task<bool> eliminarInstitucion(int id);
    }
}
