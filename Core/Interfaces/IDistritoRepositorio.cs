using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IDistritoRepositorio {
        //los metodos que tendra en repositorio
        Task<Distrito> crearDistrito(Distrito distrito);
        Task<IReadOnlyList<Distrito>> obtenerDistritos();
        Task<Distrito> obtenerDistrito(int id);
        Task<Distrito> actualizarDistrito(Distrito distrito);
        Task<bool> eliminarDistrito(int id);
    }
}
