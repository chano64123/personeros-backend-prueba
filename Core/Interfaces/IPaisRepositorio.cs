using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IPaisRepositorio {
        //los metodos que tendra en repositorio
        Task<Pais> crearPais(Pais pais);
        Task<IReadOnlyList<Pais>> obtenerPaises();
        Task<Pais> obtenerPais(int id);
        Task<Pais> actualizarPais(Pais pais);
        Task<bool> eliminarPais(int id);
    }
}