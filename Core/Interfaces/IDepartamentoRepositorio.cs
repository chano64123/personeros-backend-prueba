using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
    public interface IDepartamentoRepositorio {
        //los metodos que tendra en repositorio
        Task<Departamento> crearDepartamento(Departamento departamento);
        Task<IReadOnlyList<Departamento>> obtenerDepartamentos();
        Task<Departamento> obtenerDepartamento(int id);
        Task<Departamento> actualizarDepartamento(Departamento departamento);
        Task<bool> eliminarDepartamento(int id);
    }
}
