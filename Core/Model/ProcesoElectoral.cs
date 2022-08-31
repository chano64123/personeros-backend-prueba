using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class ProcesoElectoral {
        [Key]
        public int idProcesoElectoral { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int anio { get; set; }
        [Required]
        public string tipo { get; set; }
    }
}
