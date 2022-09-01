using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Especificacion {
    public class DepartamentoConPaisEspecificacion : EspecificacionBase<Departamento> {
        public DepartamentoConPaisEspecificacion() {
            AgregarInclude(x => x.pais);
        }

        public DepartamentoConPaisEspecificacion(int id) : base(x => x.idDepartamento == id) {
            AgregarInclude(x => x.pais);
        }
    }

    public class ProvinciaConDepartamentoPaisEspecificacion : EspecificacionBase<Provincia> {
        public ProvinciaConDepartamentoPaisEspecificacion() {
            AgregarInclude(x => x.departamento.pais);
        }

        public ProvinciaConDepartamentoPaisEspecificacion(int id) : base(x => x.idProvincia == id) {
            AgregarInclude(x => x.departamento.pais);
        }
    }

    public class DistritoConProvinciaDepartamentoPaisEspecificacion : EspecificacionBase<Distrito> {
        public DistritoConProvinciaDepartamentoPaisEspecificacion() {
            AgregarInclude(x => x.provincia.departamento.pais);
        }

        public DistritoConProvinciaDepartamentoPaisEspecificacion(int id) : base(x => x.idDistrito == id) {
            AgregarInclude(x => x.provincia.departamento.pais);
        }
    }
}
