using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDetalles.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Suplidores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Suplidores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Suplidores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Suplidores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
