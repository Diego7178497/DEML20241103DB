using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEML20241103.Migrations
{
    public partial class DEML202411032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProyectoId",
                table: "Proyectos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DetProyectoId",
                table: "DetProyectos",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proyectos",
                newName: "ProyectoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetProyectos",
                newName: "DetProyectoId");
        }
    }
}
