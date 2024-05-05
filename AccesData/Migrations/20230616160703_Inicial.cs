using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesData.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo_huesped = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Cabañas",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JacuzziPrivado_JacuzziPrivado = table.Column<bool>(type: "bit", nullable: false),
                    Habilitada = table.Column<bool>(type: "bit", nullable: false),
                    NumHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad_CapacidadCabaña = table.Column<int>(type: "int", nullable: false),
                    NombreTipo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabañas", x => x.Nombre);
                    table.ForeignKey(
                        name: "FK_Cabañas_Tipos_NombreTipo",
                        column: x => x.NombreTipo,
                        principalTable: "Tipos",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Trabajador_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCabaña = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabañas_NombreCabaña",
                        column: x => x.NombreCabaña,
                        principalTable: "Cabañas",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabañas_NombreTipo",
                table: "Cabañas",
                column: "NombreTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_NombreCabaña",
                table: "Mantenimientos",
                column: "NombreCabaña");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabañas");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
