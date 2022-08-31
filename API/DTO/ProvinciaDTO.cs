using Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTO {
    public class ProvinciaDTO {
        public int idProvincia { get; set; }
        public string nombre { get; set; }
        public DepartamentoDTO departamento { get; set; }
    }
}
