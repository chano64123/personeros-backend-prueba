using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IPartidoPoliticoRepositorio {
        //los metodos que tendra en repositorio
        Task<PartidoPolitico> crearPartidoPolitico(PartidoPolitico partidoPolitico);
        Task<IReadOnlyList<PartidoPolitico>> obtenerPartidosPoliticos();
        Task<PartidoPolitico> obtenerPartidoPolitico(int id);
        Task<PartidoPolitico> actualizarPartidoPolitico(PartidoPolitico partidoPolitico);
        Task<bool> eliminarPartidoPolitico(int id);
    }
}
