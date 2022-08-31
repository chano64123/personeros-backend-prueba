using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IProcesoElectoralRepositorio {
        //los metodos que tendra en repositorio
        Task<ProcesoElectoral> crearProcesoElectoral(ProcesoElectoral procesoElectoral);
        Task<IReadOnlyList<ProcesoElectoral>> obtenerProcesosElectorales();
        Task<ProcesoElectoral> obtenerProcesoElectoral(int id);
        Task<ProcesoElectoral> actualizarProcesoElectoral(ProcesoElectoral procesoElectoral);
        Task<bool> eliminarProcesoElectoral(int id);
    }
}
