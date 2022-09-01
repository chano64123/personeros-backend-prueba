using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Especificacion;
using AutoMapper;
using API.DTO;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase {
        private readonly IRepositorio<Provincia> repoProvincia;
        private IMapper mapper;
        protected ResponseDTO response;

        public ProvinciaController(IRepositorio<Provincia> repoProvincia, IMapper mapper) {
            response = new ResponseDTO();
            this.repoProvincia = repoProvincia;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvinciaDTO>>> obtenerProvincias() {
            IReadOnlyCollection<Provincia> provincias;
            int code;
            try {
                var especificacion = new ProvinciaConDepartamentoPaisEspecificacion();
                provincias = await repoProvincia.obtenerTodosEspecificacionAsync(especificacion);
                response.success = true;
                response.displayMessage = provincias.Count == 0 ? "No se encontraron provincias" : "Lista de Provincias (" + provincias.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<Provincia>, IReadOnlyCollection<ProvinciaDTO>>(provincias);
                code = provincias.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinciaDTO>> obtenerProvincia(int id) {
            Provincia provincia = new();
            int code;
            try {
                var especificacion = new ProvinciaConDepartamentoPaisEspecificacion(id);
                provincia = await repoProvincia.obtenerPorIdEspecificoAsync(especificacion);
                response.success = true;
                response.displayMessage = provincia == null ? "No se encontro la provincia buscada" : "Provincia buscada (" + provincia.nombre + ")";
                response.result = mapper.Map<Provincia, ProvinciaDTO>(provincia);
                code = provincia == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<ProvinciaDTO>> crearProvincia(Provincia provincia) {
            int code;
            try {
                provincia = await repoProvincia.crearAsync(provincia);
                var especificacion = new ProvinciaConDepartamentoPaisEspecificacion(provincia.idDepartamento);
                provincia = await repoProvincia.obtenerPorIdEspecificoAsync(especificacion);
                response.result = mapper.Map<Provincia, ProvinciaDTO>(provincia);
                response.success = true;
                response.displayMessage = "Provincia creada correctamente";
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
        public async Task<ActionResult<ProvinciaDTO>> actualizarProvincia(Provincia provincia) {
            int code;
            try {
                provincia = await repoProvincia.actualizarAsync(provincia);
                var especificacion = new ProvinciaConDepartamentoPaisEspecificacion(provincia.idDepartamento);
                provincia = await repoProvincia.obtenerPorIdEspecificoAsync(especificacion);
                response.result = mapper.Map<Provincia, ProvinciaDTO>(provincia);
                response.success = true;
                response.displayMessage = "Provincia actualizada correctamente";
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
        public async Task<ActionResult<bool>> eliminarProvincia(int id) {
            int code;
            try {
                bool provinciaEliminado = await repoProvincia.eliminarPorIdAsync(id);
                response.success = provinciaEliminado;
                response.displayMessage = provinciaEliminado ? "Provincia eliminada correctamente" : "No se pudo eliminar la Provincia";
                code = provinciaEliminado ? 301 : 400;
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
