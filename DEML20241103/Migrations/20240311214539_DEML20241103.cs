using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEML20241103.Migrations
{
    public partial class DEML20241103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "DetProyectos",
                columns: table => new
                {
                    DetProyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetProyectos", x => x.DetProyectoId);
                    table.ForeignKey(
                        name: "FK_DetProyectos_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetProyectos_ProyectoId",
                table: "DetProyectos",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetProyectos");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
