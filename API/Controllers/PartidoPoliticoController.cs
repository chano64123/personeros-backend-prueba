using API.DTO;
using AutoMapper;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoPoliticoController : ControllerBase {
        private readonly IRepositorio<PartidoPolitico> repoPartidoPolitico;
        public IMapper mapper;
        protected ResponseDTO response;

        public PartidoPoliticoController(IRepositorio<PartidoPolitico> repoPartidoPolitico, IMapper mapper) {
            response = new ResponseDTO();
            this.repoPartidoPolitico = repoPartidoPolitico;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartidoPoliticoDTO>>> obtenerPartidosPoliticos() {
            IReadOnlyCollection<PartidoPolitico> partidosPoliticos;
            int code;
            try {
                partidosPoliticos = await repoPartidoPolitico.obtenerTodosAsync();
                response.success = true;
                response.displayMessage = partidosPoliticos.Count == 0 ? "No se encontraron Partidos Políticos" : "Lista de Partidos Políticos (" + partidosPoliticos.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<PartidoPolitico>, IReadOnlyCollection<PartidoPoliticoDTO>>(partidosPoliticos);
                code = partidosPoliticos.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoPoliticoDTO>> obtenerPartidoPolitico(int id) {
            PartidoPolitico partidoPolitico = new();
            int code;
            try {
                partidoPolitico = await repoPartidoPolitico.obtenerPorIdAsync(id);
                response.success = true;
                response.displayMessage = partidoPolitico == null ? "No se encontro el partido político buscado" : "Partido Político buscado (" + partidoPolitico.nombre + ")";
                response.result = mapper.Map<PartidoPolitico, PartidoPoliticoDTO>(partidoPolitico);
                code = partidoPolitico == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<PartidoPoliticoDTO>> crearPartidoPolitico(PartidoPolitico partidoPolitico) {
            int code;
            try {
                partidoPolitico = await repoPartidoPolitico.crearAsync(partidoPolitico);
                response.success = true;
                response.displayMessage = "Partido Político creado correctamente";
                response.result = mapper.Map<PartidoPolitico, PartidoPoliticoDTO>(partidoPolitico);
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
        public async Task<ActionResult<PartidoPoliticoDTO>> actualizarPartidoPolitico(PartidoPolitico partidoPolitico) {
            int code;
            try {
                partidoPolitico = await repoPartidoPolitico.actualizarAsync(partidoPolitico);
                response.success = true;
                response.displayMessage = "Partido PolÍtico actualizado correctamente";
                response.result = mapper.Map<PartidoPolitico, PartidoPoliticoDTO>(partidoPolitico);
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
        public async Task<ActionResult<bool>> eliminarPartidoPolitico(int id) {
            int code;
            try {
                bool partidoPoliticoEliminado = await repoPartidoPolitico.eliminarPorIdAsync(id);
                response.success = partidoPoliticoEliminado;
                response.displayMessage = partidoPoliticoEliminado ? "Partido Político eliminado correctamente" : "No se pudo eliminar el Partido Político";
                code = partidoPoliticoEliminado ? 301 : 400;
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
