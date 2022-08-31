using Core.Interfaces;
using Core.Model.DTO;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Especificacion;
using AutoMapper;
using API.DTO;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase {
        private readonly IRepositorio<Departamento> repoDepartamento;
        private IMapper mapper;
        protected ResponseDTO response;

        public DepartamentoController(IRepositorio<Departamento> repoDepartamento, IMapper mapper) {
            response = new ResponseDTO();
            this.repoDepartamento = repoDepartamento;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartamentoDTO>>> obtenerDepartamentos() {
            IReadOnlyCollection<Departamento> departamentos;
            int code;
            try {
                var especificacion = new DepartamentoConPaisEspecificacion();
                departamentos = await repoDepartamento.obtenerTodosEspecificacionAsync(especificacion);
                response.success = true;
                response.displayMessage = departamentos.Count == 0 ? "No se encontraron departamentos" : "Lista de Departamentos (" + departamentos.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<Departamento>, IReadOnlyCollection<DepartamentoDTO>>(departamentos);
                code = departamentos.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoDTO>> obtenerDepartamento(int id) {
            Departamento departamento = new();
            int code;
            try {
                var especificacion = new DepartamentoConPaisEspecificacion(id);
                departamento = await repoDepartamento.obtenerPorIdEspecificoAsync(especificacion);
                response.success = true;
                response.displayMessage = departamento == null ? "No se encontro el departamento buscado" : "Departamento buscado (" + departamento.nombre + ")";
                response.result = mapper.Map<Departamento, DepartamentoDTO>(departamento);
                code = departamento == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentoDTO>> crearDepartamento(Departamento departamento) {
            int code;
            try {
                departamento = await repoDepartamento.crearAsync(departamento);
                var especificacion = new DepartamentoConPaisEspecificacion(departamento.idDepartamento);
                response.result = await repoDepartamento.obtenerPorIdEspecificoAsync(especificacion);
                response.displayMessage = "Departamento creado correctamente";
                response.success = true;
                code = 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPut]
        public async Task<ActionResult<DepartamentoDTO>> actualizarDepartamento(Departamento departamento) {
            int code;
            try {
                departamento = await repoDepartamento.actualizarAsync(departamento);
                var especificacion = new DepartamentoConPaisEspecificacion(departamento.idDepartamento);
                response.result = await repoDepartamento.obtenerPorIdEspecificoAsync(especificacion);
                response.success = true;
                response.displayMessage = "Departamento actualizado correctamente";
                code = 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 304;
            }
            return StatusCode(code, response);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> eliminarDepartamento(int id) {
            int code;
            try {
                bool departamentoEliminado = await repoDepartamento.eliminarPorIdAsync(id);
                response.success = departamentoEliminado;
                response.displayMessage = departamentoEliminado ? "Departamento eliminado correctamente" : "No se pudo eliminar el Departamento";
                code = 301;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }
    }
}
