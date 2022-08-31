using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface ITipoUsuarioRepositorio {
        //los metodos que tendra en repositorio
        Task<TipoUsuario> crearTipoUsuario(TipoUsuario tipoUsuario);
        Task<IReadOnlyList<TipoUsuario>> obtenerTiposUsuarios();
        Task<TipoUsuario> obtenerTipoUsuario(int id);
        Task<TipoUsuario> actualizarTipoUsuario(TipoUsuario tipoUsuario);
        Task<bool> eliminarTipoUsuario(int id);
    }
}
