using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Combos_ComboId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ComboId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Productos");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoId",
                table: "Combos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Combos_ProductoId",
                table: "Combos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Productos_ProductoId",
                table: "Combos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Productos_ProductoId",
                table: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Combos_ProductoId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Combos");

            migrationBuilder.AddColumn<Guid>(
                name: "ComboId",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ComboId",
                table: "Productos",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Combos_ComboId",
                table: "Productos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
