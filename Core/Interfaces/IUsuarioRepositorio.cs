using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IUsuarioRepositorio {
        //los metodos que tendra en repositorio
        Task<Usuario> crearUsuario(Usuario usuario);
        Task<IReadOnlyList<Usuario>> obtenerUsuarios();
        Task<Usuario> obtenerUsuario(int id);
        Task<Usuario> actualizarUsuario(Usuario usuario);
        Task<bool> eliminarUsuario(int id);
    }
}
