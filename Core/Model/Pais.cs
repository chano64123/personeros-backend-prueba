using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Core.Model {
    public class Pais {
        [Key]
        public int idPais { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
