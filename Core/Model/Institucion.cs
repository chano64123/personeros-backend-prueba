using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public  class Institucion {
        [Key]
        public int idInstitucion { get; set; }
        [Required]
        public int idDistrito { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        public string referencia { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        [ForeignKey("idDistrito")]
        public Distrito distrito { get; set; }
    }
}
