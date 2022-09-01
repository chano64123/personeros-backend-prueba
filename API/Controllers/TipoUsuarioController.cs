using API.DTO;
using AutoMapper;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase {
        private readonly IRepositorio<TipoUsuario> repoTipoUsuario;
        public IMapper mapper;
        protected ResponseDTO response;

        public TipoUsuarioController(IRepositorio<TipoUsuario> repoTipoUsuario, IMapper mapper) {
            response = new ResponseDTO();
            this.repoTipoUsuario = repoTipoUsuario;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoUsuarioDTO>>> obtenerTiposUsuarios() {
            IReadOnlyCollection<TipoUsuario> tiposUsuarios;
            int code;
            try {
                tiposUsuarios = await repoTipoUsuario.obtenerTodosAsync();
                response.success = true;
                response.displayMessage = tiposUsuarios.Count == 0 ? "No se encontraron tipos de usuario" : "Lista de Tipos de Usuarios (" + tiposUsuarios.Count + ")";
                response.result = mapper.Map<IReadOnlyCollection<TipoUsuario>, IReadOnlyCollection<TipoUsuarioDTO>>(tiposUsuarios);
                code = tiposUsuarios.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuarioDTO>> obtenerTipoUsuario(int id) {
            TipoUsuario tipoUsuario = new();
            int code;
            try {
                tipoUsuario = await repoTipoUsuario.obtenerPorIdAsync(id);
                response.success = true;
                response.displayMessage = tipoUsuario == null ? "No se encontro el tipo de usuario buscado" : "Tipo de Usuario buscado (" + tipoUsuario.nombre + ")";
                response.result = mapper.Map<TipoUsuario, TipoUsuarioDTO>(tipoUsuario);
                code = tipoUsuario == null ? 404 : 200;
            } catch (Exception ex) {
                response.success = false;
                response.displayMessage = "Error con el servidor";
                response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuarioDTO>> crearTipoUsuario(TipoUsuario tipoUsuario) {
            int code;
            try {
                tipoUsuario = await repoTipoUsuario.crearAsync(tipoUsuario);
                response.success = true;
                response.displayMessage = "Tipo de Usuario creado correctamente";
                response.result = mapper.Map<TipoUsuario, TipoUsuarioDTO>(tipoUsuario);
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
        public async Task<ActionResult<TipoUsuarioDTO>> actualizarTipoUsuario(TipoUsuario tipoUsuario) {
            int code;
            try {
                tipoUsuario = await repoTipoUsuario.actualizarAsync(tipoUsuario);
                response.success = true;
                response.displayMessage = "Tipo de Usuario actualizado correctamente";
                response.result = mapper.Map<TipoUsuario, TipoUsuarioDTO>(tipoUsuario);
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
        public async Task<ActionResult<bool>> eliminarTipoUsuario(int id) {
            int code;
            try {
                bool tipoUsuarioEliminado = await repoTipoUsuario.eliminarPorIdAsync(id);
                response.success = tipoUsuarioEliminado;
                response.displayMessage = tipoUsuarioEliminado ? "Tipo de Usuario eliminado correctamente" : "No se pudo eliminar el Tipo de Usuario";
                code = tipoUsuarioEliminado ? 301 : 400;
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
