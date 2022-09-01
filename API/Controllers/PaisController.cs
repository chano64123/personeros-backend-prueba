using API.DTO;
using AutoMapper;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase {
        private readonly IRepositorio<Pais> repoPais;
        public IMapper mapper;
        protected ResponseDTO response;

        public PaisController(IRepositorio<Pais> repoPais, IMapper mapper) {
            response = new ResponseDTO();
            this.repoPais = repoPais;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaisDTO>>> obtenerPaises() {
            IReadOnlyCollection<Pais> paises;
            int code;
            try {
                paises = await repoPais.obtenerTodosAsync();
                response.success = true;
                response.displayMessage = paises.Count == 0 ? "No se encontraron paises" : "Lista de Paises (" + paises.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<Pais>, IReadOnlyCollection<PaisDTO>>(paises);
                code = paises.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDTO>> obtenerPais(int id) {
            Pais pais = new();
            int code;
            try {
                pais = await repoPais.obtenerPorIdAsync(id);
                response.success = true;
                response.displayMessage = pais == null ? "No se encontro el país buscado" : "País buscado (" + pais.nombre + ")";
                response.result = mapper.Map<Pais, PaisDTO>(pais);
                code = pais == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<PaisDTO>> crearPais(Pais pais) {
            int code;
            try {
                pais = await repoPais.crearAsync(pais);
                response.success = true;
                response.displayMessage = "País creado correctamente";
                response.result = mapper.Map<Pais, PaisDTO>(pais);
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
        public async Task<ActionResult<PaisDTO>> actualizarPais(Pais pais) {
            int code;
            try {
                pais = await repoPais.actualizarAsync(pais);
                response.success = true;
                response.displayMessage = "País actualizado correctamente";
                response.result = mapper.Map<Pais, PaisDTO>(pais);
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
        public async Task<ActionResult<bool>> eliminarPais(int id) {
            int code;
            try {
                bool paisEliminado = await repoPais.eliminarPorIdAsync(id);
                response.success = paisEliminado;
                response.displayMessage = paisEliminado ? "País eliminado correctamente" : "No se pudo eliminar el País";
                code = paisEliminado ? 301 : 400;
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
