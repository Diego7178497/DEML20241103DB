using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEML20241103.Migrations
{
    public partial class DEML20241103DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaInicial",
                table: "DetProyectos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicial",
                table: "DetProyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
