using Core.Model;
using Core.Model.DTO;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase {
        private readonly ApplicationDbContext _db;
        protected ResponseDTO _response;

        public PaisController(ApplicationDbContext db) {
            _db = db;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<List<Pais>>> getPaises() {
            List<Pais> paises = new();
            int code;
            try {
                paises = await _db.Pais.ToListAsync();
                _response.success = true;
                _response.displayMessage = paises.Count == 0 ? "No se encontraron paises" : "Lista de Paises ("+ paises.Count + ")";
                _response.result = paises;
                code = paises.Count == 0 ? 404 : 200;
            } catch (Exception ex) {
                _response.success = false;
                _response.displayMessage = "Error con el servidor";
                _response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code,_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> obtenerPaises(int id) {
            Pais pais = new();
            int code;
            try {
                pais = await _db.Pais.FindAsync(id);
                _response.success = true;
                _response.displayMessage = pais == null ? "No se encontraron paises" : "Paises (" + pais.nombre + ")";
                _response.result = pais;
                code = pais == null ? 404 : 200;
            } catch (Exception ex) {
                _response.success = false;
                _response.displayMessage = "Error con el servidor";
                _response.errorMessage = new List<string> { ex.ToString() };
                code = 500;
            }
            return StatusCode(code, _response);
        }
    }
}
