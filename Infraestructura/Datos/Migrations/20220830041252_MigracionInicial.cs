using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Datos.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    idPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.idPais);
                });

            migrationBuilder.CreateTable(
                name: "PartidoPolitico",
                columns: table => new
                {
                    idPartidoPolitico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidoPolitico", x => x.idPartidoPolitico);
                });

            migrationBuilder.CreateTable(
                name: "ProcesoElectoral",
                columns: table => new
                {
                    idProcesoElectoral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesoElectoral", x => x.idProcesoElectoral);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    idDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPais = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.idDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_idPais",
                        column: x => x.idPais,
                        principalTable: "Pais",
                        principalColumn: "idPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    idProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDepartamento = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.idProvincia);
                    table.ForeignKey(
                        name: "FK_Provincia_Departamento_idDepartamento",
                        column: x => x.idDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    idDistrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProvincia = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.idDistrito);
                    table.ForeignKey(
                        name: "FK_Distrito_Provincia_idProvincia",
                        column: x => x.idProvincia,
                        principalTable: "Provincia",
                        principalColumn: "idProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Institucion",
                columns: table => new
                {
                    idInstitucion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDistrito = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    latitud = table.Column<double>(type: "float", nullable: false),
                    longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucion", x => x.idInstitucion);
                    table.ForeignKey(
                        name: "FK_Institucion_Distrito_idDistrito",
                        column: x => x.idDistrito,
                        principalTable: "Distrito",
                        principalColumn: "idDistrito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    idDistrito = table.Column<int>(type: "int", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idPersona);
                    table.ForeignKey(
                        name: "FK_Persona_Distrito_idDistrito",
                        column: x => x.idDistrito,
                        principalTable: "Distrito",
                        principalColumn: "idDistrito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    idAula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idInstitucion = table.Column<int>(type: "int", nullable: false),
                    pabellon = table.Column<int>(type: "int", nullable: false),
                    piso = table.Column<int>(type: "int", nullable: false),
                    numeroAula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_Aula_Institucion_idInstitucion",
                        column: x => x.idInstitucion,
                        principalTable: "Institucion",
                        principalColumn: "idInstitucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    idPartidoPolitico = table.Column<int>(type: "int", nullable: false),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    clave = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_PartidoPolitico_idPartidoPolitico",
                        column: x => x.idPartidoPolitico,
                        principalTable: "PartidoPolitico",
                        principalColumn: "idPartidoPolitico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_idPersona",
                        column: x => x.idPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    idMesa = table.Column<int>(type: "int", nullable: false),
                    idAula = table.Column<int>(type: "int", nullable: false),
                    idProcesoElectoral = table.Column<int>(type: "int", nullable: false),
                    numeroMesa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.idMesa);
                    table.ForeignKey(
                        name: "FK_Mesa_Aula_idMesa",
                        column: x => x.idMesa,
                        principalTable: "Aula",
                        principalColumn: "idAula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesa_ProcesoElectoral_idProcesoElectoral",
                        column: x => x.idProcesoElectoral,
                        principalTable: "ProcesoElectoral",
                        principalColumn: "idProcesoElectoral",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personero",
                columns: table => new
                {
                    idPersonero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idMesa = table.Column<int>(type: "int", nullable: false),
                    cantidadVotosPartido = table.Column<int>(type: "int", nullable: false),
                    cantidadVotosOtros = table.Column<int>(type: "int", nullable: false),
                    cantidadVotosBlancos = table.Column<int>(type: "int", nullable: false),
                    cantidadVotosNulos = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personero", x => x.idPersonero);
                    table.ForeignKey(
                        name: "FK_Personero_Mesa_idMesa",
                        column: x => x.idMesa,
                        principalTable: "Mesa",
                        principalColumn: "idMesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personero_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aula_idInstitucion",
                table: "Aula",
                column: "idInstitucion");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_idPais",
                table: "Departamento",
                column: "idPais");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_idProvincia",
                table: "Distrito",
                column: "idProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Institucion_idDistrito",
                table: "Institucion",
                column: "idDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_idProcesoElectoral",
                table: "Mesa",
                column: "idProcesoElectoral");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idDistrito",
                table: "Persona",
                column: "idDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Personero_idMesa",
                table: "Personero",
                column: "idMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Personero_idUsuario",
                table: "Personero",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_idDepartamento",
                table: "Provincia",
                column: "idDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idPartidoPolitico",
                table: "Usuario",
                column: "idPartidoPolitico");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idPersona",
                table: "Usuario",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personero");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "ProcesoElectoral");

            migrationBuilder.DropTable(
                name: "PartidoPolitico");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropTable(
                name: "Institucion");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
