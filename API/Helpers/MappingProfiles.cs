using API.DTO;
using AutoMapper;
using Core.Model;

namespace API.Helpers {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Pais, PaisDTO>();
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<Provincia, ProvinciaDTO>();
        }
    }
}
