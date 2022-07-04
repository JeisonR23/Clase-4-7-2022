using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDetalles.Migrations
{
    public partial class agregandoproductosiniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "ComprasDetalles",
                newName: "Precio");

            migrationBuilder.AddColumn<double>(
                name: "Existencia",
                table: "ComprasDetalles",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[] { 1, 3.0, "Huevos", 0.0, 7.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[] { 2, 50.0, "Cebollas", 0.0, 85.0 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[] { 3, 30.0, "Lechuga", 0.0, 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "ComprasDetalles");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "ComprasDetalles",
                newName: "Cantidad");
        }
    }
}
