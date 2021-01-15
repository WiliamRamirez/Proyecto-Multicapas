using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TablaProducto_Detalles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_DetallesCompras_DetalleCompraId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_DetalleCompraId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "DetalleCompraId",
                table: "Productos");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_ProductoId",
                table: "DetallesCompras",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesCompras_Productos_ProductoId",
                table: "DetallesCompras",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesCompras_Productos_ProductoId",
                table: "DetallesCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCompras_ProductoId",
                table: "DetallesCompras");

            migrationBuilder.AddColumn<Guid>(
                name: "DetalleCompraId",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleCompraId",
                table: "Productos",
                column: "DetalleCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_DetallesCompras_DetalleCompraId",
                table: "Productos",
                column: "DetalleCompraId",
                principalTable: "DetallesCompras",
                principalColumn: "DetalleCompraId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
