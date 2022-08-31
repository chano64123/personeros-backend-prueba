using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Aula {
        [Key]
        public int idAula { get; set; }
        [Required]
        public int idInstitucion { get; set; }
        [Required]
        public int pabellon { get; set; }
        [Required]
        public int piso { get; set; }
        [Required]
        public int numeroAula { get; set; }
        [ForeignKey("idInstitucion")]
        public Institucion institucion { get; set; }
    }
}
