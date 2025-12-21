using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: false),
                    Esquina = table.Column<string>(type: "text", nullable: false),
                    NumeroPuerta = table.Column<string>(type: "text", nullable: false),
                    Barrio = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Contrasena = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExAlumnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AnioEgreso = table.Column<int>(type: "integer", nullable: false),
                    DireccionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExAlumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExAlumnos_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExAlumnos_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Modalidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Ubicacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Instituto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AdministradorId = table.Column<Guid>(type: "uuid", nullable: false),
                    EspecialidadId = table.Column<Guid>(type: "uuid", nullable: true),
                    EstudioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursos_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Ubicacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdministradorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfertasLaborales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Modalidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Salario = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasLaborales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertasLaborales_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprendimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Imagen = table.Column<string>(type: "text", nullable: false),
                    EstudioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExAlumnoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DireccionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprendimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprendimientos_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emprendimientos_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprendimientos_ExAlumnos_ExAlumnoId",
                        column: x => x.ExAlumnoId,
                        principalTable: "ExAlumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExAlumnoEstudio",
                columns: table => new
                {
                    EstudiosId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExAlumnosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExAlumnoEstudio", x => new { x.EstudiosId, x.ExAlumnosId });
                    table.ForeignKey(
                        name: "FK_ExAlumnoEstudio_Estudios_EstudiosId",
                        column: x => x.EstudiosId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExAlumnoEstudio_ExAlumnos_ExAlumnosId",
                        column: x => x.ExAlumnosId,
                        principalTable: "ExAlumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Texto = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ExAlumnoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_ExAlumnos_ExAlumnoId",
                        column: x => x.ExAlumnoId,
                        principalTable: "ExAlumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaLaboralEstudio",
                columns: table => new
                {
                    EstudiosId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfertasLaboralesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaLaboralEstudio", x => new { x.EstudiosId, x.OfertasLaboralesId });
                    table.ForeignKey(
                        name: "FK_OfertaLaboralEstudio_Estudios_EstudiosId",
                        column: x => x.EstudiosId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaLaboralEstudio_OfertasLaborales_OfertasLaboralesId",
                        column: x => x.OfertasLaboralesId,
                        principalTable: "OfertasLaborales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EmprendimientoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_Emprendimientos_EmprendimientoId",
                        column: x => x.EmprendimientoId,
                        principalTable: "Emprendimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Imagen = table.Column<string>(type: "text", nullable: false),
                    EmprendimientoId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmprendimientoId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Emprendimientos_EmprendimientoId",
                        column: x => x.EmprendimientoId,
                        principalTable: "Emprendimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Emprendimientos_EmprendimientoId1",
                        column: x => x.EmprendimientoId1,
                        principalTable: "Emprendimientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IconName = table.Column<string>(type: "text", nullable: false),
                    Costo = table.Column<double>(type: "double precision", nullable: true),
                    EmprendimientoId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmprendimientoId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Emprendimientos_EmprendimientoId",
                        column: x => x.EmprendimientoId,
                        principalTable: "Emprendimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Emprendimientos_EmprendimientoId1",
                        column: x => x.EmprendimientoId1,
                        principalTable: "Emprendimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Texto = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PublicacionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExAlumnoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_ExAlumnos_ExAlumnoId",
                        column: x => x.ExAlumnoId,
                        principalTable: "ExAlumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadDias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisponibilidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    DisponibilidadId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadDias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisponibilidadDias_Disponibilidades_DisponibilidadId",
                        column: x => x.DisponibilidadId,
                        principalTable: "Disponibilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisponibilidadDias_Disponibilidades_DisponibilidadId1",
                        column: x => x.DisponibilidadId1,
                        principalTable: "Disponibilidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AdministradorId",
                table: "Cursos",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_EstudioId",
                table: "Cursos",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadDias_DisponibilidadId",
                table: "DisponibilidadDias",
                column: "DisponibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadDias_DisponibilidadId1",
                table: "DisponibilidadDias",
                column: "DisponibilidadId1");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_EmprendimientoId",
                table: "Disponibilidades",
                column: "EmprendimientoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprendimientos_DireccionId",
                table: "Emprendimientos",
                column: "DireccionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprendimientos_EstudioId",
                table: "Emprendimientos",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprendimientos_ExAlumnoId",
                table: "Emprendimientos",
                column: "ExAlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AdministradorId",
                table: "Eventos",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExAlumnoEstudio_ExAlumnosId",
                table: "ExAlumnoEstudio",
                column: "ExAlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_ExAlumnos_DireccionId",
                table: "ExAlumnos",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaLaboralEstudio_OfertasLaboralesId",
                table: "OfertaLaboralEstudio",
                column: "OfertasLaboralesId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasLaborales_EmpresaId",
                table: "OfertasLaborales",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_EmprendimientoId",
                table: "Portfolios",
                column: "EmprendimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_EmprendimientoId1",
                table: "Portfolios",
                column: "EmprendimientoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_ExAlumnoId",
                table: "Publicaciones",
                column: "ExAlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_ExAlumnoId",
                table: "Respuestas",
                column: "ExAlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PublicacionId",
                table: "Respuestas",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_EmprendimientoId",
                table: "Servicios",
                column: "EmprendimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_EmprendimientoId1",
                table: "Servicios",
                column: "EmprendimientoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "DisponibilidadDias");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "ExAlumnoEstudio");

            migrationBuilder.DropTable(
                name: "OfertaLaboralEstudio");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Disponibilidades");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "OfertasLaborales");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Emprendimientos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "ExAlumnos");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
