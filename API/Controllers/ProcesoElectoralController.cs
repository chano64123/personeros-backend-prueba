using API.DTO;
using AutoMapper;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoElectoralController : ControllerBase {
        private readonly IRepositorio<ProcesoElectoral> repoProcesoElectoral;
        public IMapper mapper;
        protected ResponseDTO response;

        public ProcesoElectoralController(IRepositorio<ProcesoElectoral> repoProcesoElectoral, IMapper mapper) {
            response = new ResponseDTO();
            this.repoProcesoElectoral = repoProcesoElectoral;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProcesoElectoralDTO>>> obtenerProcesosElectorales() {
            IReadOnlyCollection<ProcesoElectoral> procesosElectorales;
            int code;
            try {
                procesosElectorales = await repoProcesoElectoral.obtenerTodosAsync();
                response.success = true;
                response.displayMessage = procesosElectorales.Count == 0 ? "No se encontraron Procesos Electorales" : "Lista de Procesos Electorales (" + procesosElectorales.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<ProcesoElectoral>, IReadOnlyCollection<ProcesoElectoralDTO>>(procesosElectorales);
                code = procesosElectorales.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcesoElectoralDTO>> obtenerProcesoElectoral(int id) {
            ProcesoElectoral procesoElectoral = new();
            int code;
            try {
                procesoElectoral = await repoProcesoElectoral.obtenerPorIdAsync(id);
                response.success = true;
                response.displayMessage = procesoElectoral == null ? "No se encontro el proceso electoral buscado" : "Proceso Electoral buscado (" + procesoElectoral.nombre + ")";
                response.result = mapper.Map<ProcesoElectoral, ProcesoElectoralDTO>(procesoElectoral);
                code = procesoElectoral == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<ProcesoElectoralDTO>> crearProcesoElectoral(ProcesoElectoral procesoElectoral) {
            int code;
            try {
                procesoElectoral = await repoProcesoElectoral.crearAsync(procesoElectoral);
                response.success = true;
                response.displayMessage = "Proceso Electoral creado correctamente";
                response.result = mapper.Map<ProcesoElectoral, ProcesoElectoralDTO>(procesoElectoral);
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
        public async Task<ActionResult<ProcesoElectoralDTO>> actualizarProcesoElectoral(ProcesoElectoral procesoElectoral) {
            int code;
            try {
                procesoElectoral = await repoProcesoElectoral.actualizarAsync(procesoElectoral);
                response.success = true;
                response.displayMessage = "Proceso Electoral actualizado correctamente";
                response.result = mapper.Map<ProcesoElectoral, ProcesoElectoralDTO>(procesoElectoral);
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
        public async Task<ActionResult<bool>> eliminarProcesoElectoral(int id) {
            int code;
            try {
                bool procesoElectoralEliminado = await repoProcesoElectoral.eliminarPorIdAsync(id);
                response.success = procesoElectoralEliminado;
                response.displayMessage = procesoElectoralEliminado ? "Proceso Electoral eliminado correctamente" : "No se pudo eliminar el Proceso Electoral";
                code = procesoElectoralEliminado ? 301 : 400;
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
