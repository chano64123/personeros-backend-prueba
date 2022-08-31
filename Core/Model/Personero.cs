using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Personero {
        [Key]
        public int idPersonero { get; set; }
        [Required]
        public int idUsuario { get; set; }
        [Required]
        public int idMesa { get; set; }
        [Required]
        public int cantidadVotosPartido { get; set; }
        [Required]
        public int cantidadVotosOtros { get; set; }
        [Required]
        public int cantidadVotosBlancos { get; set; }
        [Required]
        public int cantidadVotosNulos { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idUsuario")]
        public Usuario usuario { get; set; }
        [ForeignKey("idMesa")]
        public Mesa mesa { get; set; }

    }
}
