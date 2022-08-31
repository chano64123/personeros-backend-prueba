using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IAulaRepositorio {
        //los metodos que tendra en repositorio
        Task<Aula> crearAula(Aula aula);
        Task<IReadOnlyList<Aula>> obtenerAulas();
        Task<Aula> obtenerAula(int id);
        Task<Aula> actualizarAula(Aula aula);
        Task<bool> eliminarAula(int id);
    }
}
