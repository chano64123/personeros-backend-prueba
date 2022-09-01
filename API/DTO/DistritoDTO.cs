using Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTO {
    public class DistritoDTO {
        public int idDistrito { get; set; }
        public string nombre { get; set; }
        public ProvinciaDTO provincia { get; set; }
    }
}
