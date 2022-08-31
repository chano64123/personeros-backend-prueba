using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Departamento {
        [Key]
        public int idDepartamento { get; set; }
        [Required]
        public int idPais{ get; set; }
        [Required]
        public string nombre { get; set; }
        [ForeignKey("idPais")]
        public Pais pais { get; set; }
    }
}
