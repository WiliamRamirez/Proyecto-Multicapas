using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TablaDetallesCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_DetallesCompras_DetalleCompraId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_DetalleCompraId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "DetalleCompraId",
                table: "Compras");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_CompraId",
                table: "DetallesCompras",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesCompras_Compras_CompraId",
                table: "DetallesCompras",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "CompraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesCompras_Compras_CompraId",
                table: "DetallesCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCompras_CompraId",
                table: "DetallesCompras");

            migrationBuilder.AddColumn<Guid>(
                name: "DetalleCompraId",
                table: "Compras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_DetalleCompraId",
                table: "Compras",
                column: "DetalleCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_DetallesCompras_DetalleCompraId",
                table: "Compras",
                column: "DetalleCompraId",
                principalTable: "DetallesCompras",
                principalColumn: "DetalleCompraId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
