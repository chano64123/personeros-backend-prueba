using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IMesaRepositorio {
        //los metodos que tendra en repositorio
        Task<Mesa> crearMesa(Mesa mesa);
        Task<IReadOnlyList<Mesa>> obtenerMesas();
        Task<Mesa> obtenerMesa(int id);
        Task<Mesa> actualizarMesa(Mesa mesa);
        Task<bool> eliminarMesa(int id);
    }
}
