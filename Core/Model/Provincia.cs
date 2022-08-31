using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Provincia {
        [Key]
        public int idProvincia { get; set; }
        [Required]
        public int idDepartamento { get; set; }
        [Required]
        public string nombre { get; set; }
        [ForeignKey("idDepartamento")]
        public Departamento departamento { get; set; }
    }
}
