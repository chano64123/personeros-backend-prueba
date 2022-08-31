using API.Errores;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorTestController : ControllerBase {
        private readonly ApplicationDbContext db;
        public ErrorTestController(ApplicationDbContext db) {
            this.db = db;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundError() {
            var algo = db.Pais.Find(166);
            if (algo == null) {
                return NotFound(new ApiResponse(400));
            } 
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError() {
            var algo = db.Pais.Find(166);
            var alguito = algo.ToString();
            return Ok(new ApiResponse(500));
        }

        [HttpGet("badrequest")]
        public ActionResult GetBAdRequestError() {
            return BadRequest(new ApiResponse(404));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBAdRequestError(int id) {
            return BadRequest(new ApiResponse(401));
        }
    }
}
