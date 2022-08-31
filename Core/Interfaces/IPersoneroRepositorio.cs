using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IPersoneroRepositorio {
        //los metodos que tendra en repositorio
        Task<Personero> crearPersonero(Personero personero);
        Task<IReadOnlyList<Personero>> obtenerPersoneros();
        Task<Personero> obtenerPersonero(int id);
        Task<Personero> actualizarPersonero(Personero personero);
        Task<bool> eliminarPersonero(int id);
    }
}
