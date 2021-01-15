using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgregandoEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Estado",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte>(
                name: "Estado",
                table: "Categoria",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
