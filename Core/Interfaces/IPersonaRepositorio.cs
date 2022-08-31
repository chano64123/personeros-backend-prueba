using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IPersonaRepositorio {
        //los metodos que tendra en repositorio
        Task<Persona> crearPersona(Persona persona);
        Task<IReadOnlyList<Persona>> obtenerPersonas();
        Task<Persona> obtenerPersona(int id);
        Task<Persona> actualizarPersona(Persona persona);
        Task<bool> eliminarPersona(int id);
    }
}
