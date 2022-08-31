using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IProvinciaRepositorio {
        //los metodos que tendra en repositorio
        Task<Provincia> crearProvincia(Provincia provincia);
        Task<IReadOnlyList<Provincia>> obtenerProvincias();
        Task<Provincia> obtenerProvincia(int id);
        Task<Provincia> actualizarProvincia(Provincia provincia);
        Task<bool> eliminarProvincia(int id);
    }
}
