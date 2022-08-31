using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Persona {
        [Key]
        public int idPersona { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno{ get; set; }
        [Required]
        public string dni { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public int idDistrito { get; set; }
        [Required]
        public string celular { get; set; }
        [Required]
        public string correo { get; set; }
        [ForeignKey("idDistrito")]
        public Distrito distrito { get; set; }
    }
}
