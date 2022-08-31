using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config {
    public class AulaConfiguration : IEntityTypeConfiguration<Aula> {
        public void Configure(EntityTypeBuilder<Aula> builder) {
            /* Properties */
            builder.HasKey(a => a.idAula);
            builder.Property(a => a.idInstitucion).IsRequired();
            builder.Property(a => a.pabellon).IsRequired();
            builder.Property(a => a.piso).IsRequired();
            builder.Property(a => a.numeroAula).IsRequired();
            /* Relationships */
            builder.HasOne(i => i.institucion).WithMany().HasForeignKey(a => a.idInstitucion);
        }
    }

    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento> {
        public void Configure(EntityTypeBuilder<Departamento> builder) {
            /* Properties */
            builder.HasKey(d => d.idDepartamento);
            builder.Property(d => d.nombre).IsRequired().HasMaxLength(100);
            builder.Property(d => d.idPais).IsRequired();
            /* Relationships */
            builder.HasOne(p => p.pais).WithMany().HasForeignKey(d => d.idPais);
        }
    }

    public class DistritoConfiguration : IEntityTypeConfiguration<Distrito> {
        public void Configure(EntityTypeBuilder<Distrito> builder) {
            /* Properties */
            builder.HasKey(d => d.idDistrito);
            builder.Property(d => d.nombre).IsRequired().HasMaxLength(100);
            builder.Property(d => d.idProvincia).IsRequired();
            /* Relationships */
            builder.HasOne(p => p.provincia).WithMany().HasForeignKey(d => d.idProvincia);
        }
    }

    public class InstitucionConfiguration : IEntityTypeConfiguration<Institucion> {
        public void Configure(EntityTypeBuilder<Institucion> builder) {
            /* Properties */
            builder.HasKey(i => i.idInstitucion);
            builder.Property(i => i.idDistrito).IsRequired();
            builder.Property(i => i.nombre).IsRequired().HasMaxLength(255);
            builder.Property(i => i.direccion).IsRequired().HasMaxLength(255);
            builder.Property(i => i.referencia).HasMaxLength(255);
            /* Relationships */
            builder.HasOne(d => d.distrito).WithMany().HasForeignKey(i => i.idDistrito);
        }
    }

    public class MesaConfiguration : IEntityTypeConfiguration<Mesa> {
        public void Configure(EntityTypeBuilder<Mesa> builder) {
            /* Properties */
            builder.HasKey(m => m.idMesa);
            builder.Property(m => m.idAula).IsRequired();
            builder.Property(m => m.idProcesoElectoral).IsRequired();
            builder.Property(m => m.numeroMesa).IsRequired().HasMaxLength(10);
            /* Relationships */
            builder.HasOne(a => a.aula).WithMany().HasForeignKey(m => m.idMesa);
            builder.HasOne(pe => pe.procesoElectoral).WithMany().HasForeignKey(m => m.idProcesoElectoral);
        }
    }

    public class PaisConfiguration : IEntityTypeConfiguration<Pais> {
        public void Configure(EntityTypeBuilder<Pais> builder) {
            /* Properties */
            builder.HasKey(p => p.idPais);
            builder.Property(p => p.nombre).IsRequired().HasMaxLength(100);
        }
    }

    public class PartidoPoliticoConfiguration : IEntityTypeConfiguration<PartidoPolitico> {
        public void Configure(EntityTypeBuilder<PartidoPolitico> builder) {
            /* Properties */
            builder.HasKey(pp => pp.idPartidoPolitico);
            builder.Property(pp => pp.nombre).IsRequired().HasMaxLength(255);
        }
    }

    public class PersonaConfiguration : IEntityTypeConfiguration<Persona> {
        public void Configure(EntityTypeBuilder<Persona> builder) {
            /* Properties */
            builder.HasKey(p => p.idPersona);
            builder.Property(p => p.idDistrito).IsRequired();
            builder.Property(p => p.nombres).IsRequired().HasMaxLength(50);
            builder.Property(p => p.apellidoPaterno).IsRequired().HasMaxLength(50);
            builder.Property(p => p.apellidoMaterno).HasMaxLength(50);
            builder.Property(p => p.dni).IsRequired().HasMaxLength(8);
            builder.Property(p => p.direccion).IsRequired().HasMaxLength(255);
            builder.Property(p => p.celular).IsRequired().HasMaxLength(12);
            builder.Property(p => p.correo).IsRequired().HasMaxLength(100);
            /* Relationships */
            builder.HasOne(d => d.distrito).WithMany().HasForeignKey(p => p.idDistrito);
        }
    }

    public class PersoneroConfiguration : IEntityTypeConfiguration<Personero> {
        public void Configure(EntityTypeBuilder<Personero> builder) {
            /* Properties */
            builder.HasKey(p => p.idPersonero);
            builder.Property(p => p.idUsuario).IsRequired();
            builder.Property(p => p.idMesa).IsRequired();
            builder.Property(p => p.cantidadVotosPartido).IsRequired();
            builder.Property(p => p.cantidadVotosOtros).IsRequired();
            builder.Property(p => p.cantidadVotosBlancos).IsRequired();
            builder.Property(p => p.cantidadVotosNulos).IsRequired();
            builder.Property(p => p.fecha).IsRequired();
            /* Relationships */
            builder.HasOne(u => u.usuario).WithMany().HasForeignKey(p => p.idUsuario);
            builder.HasOne(m => m.mesa).WithMany().HasForeignKey(p => p.idMesa);
        }
    }

    public class ProcesoElectoralConfiguration : IEntityTypeConfiguration<ProcesoElectoral> {
        public void Configure(EntityTypeBuilder<ProcesoElectoral> builder) {
            /* Properties */
            builder.HasKey(pe => pe.idProcesoElectoral);
            builder.Property(pe => pe.nombre).IsRequired().HasMaxLength(255);
            builder.Property(pe => pe.anio).IsRequired();
            builder.Property(pe => pe.tipo).IsRequired().HasMaxLength(100);
        }
    }

    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia> {
        public void Configure(EntityTypeBuilder<Provincia> builder) {
            /* Properties */
            builder.HasKey(p => p.idProvincia);
            builder.Property(p => p.nombre).IsRequired().HasMaxLength(100);
            builder.Property(p => p.idDepartamento).IsRequired();
            /* Relationships */
            builder.HasOne(d => d.departamento).WithMany().HasForeignKey(p => p.idDepartamento);
        }
    }

    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuario> {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder) {
            /* Properties */
            builder.HasKey(tu => tu.idTipoUsuario);
            builder.Property(tu => tu.nombre).IsRequired().HasMaxLength(100);
        }
    }

    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario> {
        public void Configure(EntityTypeBuilder<Usuario> builder) {
            /* Properties */
            builder.HasKey(u => u.idUsuario);
            builder.Property(u => u.idTipoUsuario).IsRequired();
            builder.Property(u => u.idPartidoPolitico).IsRequired();
            builder.Property(u => u.idPersona).IsRequired();
            builder.Property(u => u.nombreUsuario).IsRequired().HasMaxLength(25);
            builder.Property(u => u.clave).IsRequired().HasMaxLength(255);
            /* Relationships */
            builder.HasOne(tu => tu.tipoUsuario).WithMany().HasForeignKey(u => u.idTipoUsuario);
            builder.HasOne(pp => pp.partidoPolitico).WithMany().HasForeignKey(u => u.idPartidoPolitico);
            builder.HasOne(p => p.persona).WithMany().HasForeignKey(u => u.idPersona);
        }
    }
}
