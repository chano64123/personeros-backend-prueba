using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model {
    public class Distrito {
        [Key]
        public int idDistrito{ get; set; }
        [Required]
        public int idProvincia { get; set; }
        [Required]
        public string nombre { get; set; }
        [ForeignKey("idProvincia")]
        public Provincia provincia { get; set; }
    }
}
