using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Mesa {
        [Key]
        public int idMesa { get; set; }
        [Required]
        public int idAula { get; set; }
        [Required]
        public int idProcesoElectoral { get; set; }
        [Required]
        public string numeroMesa { get; set; }
        [ForeignKey("idAula")]
        public Aula aula { get; set; }
        [ForeignKey("idProcesoElectoral")]
        public ProcesoElectoral procesoElectoral { get; set; }
    }
}
