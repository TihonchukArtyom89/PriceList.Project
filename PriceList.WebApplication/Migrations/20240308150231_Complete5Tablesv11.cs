using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPriceListProduct_PriceListProducts_PriceListID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProductProduct_PriceListProducts_ProductID",
                table: "PriceListProductProduct");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "PriceListProductProduct",
                newName: "PriceListProductsPriceListLineID");

            migrationBuilder.RenameColumn(
                name: "PriceListID",
                table: "PriceListPriceListProduct",
                newName: "PriceListProductsPriceListLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPriceListProduct_PriceListProducts_PriceListProductsPriceListLineID",
                table: "PriceListPriceListProduct",
                column: "PriceListProductsPriceListLineID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListProductProduct_PriceListProducts_PriceListProductsPriceListLineID",
                table: "PriceListProductProduct",
                column: "PriceListProductsPriceListLineID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPriceListProduct_PriceListProducts_PriceListProductsPriceListLineID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProductProduct_PriceListProducts_PriceListProductsPriceListLineID",
                table: "PriceListProductProduct");

            migrationBuilder.RenameColumn(
                name: "PriceListProductsPriceListLineID",
                table: "PriceListProductProduct",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "PriceListProductsPriceListLineID",
                table: "PriceListPriceListProduct",
                newName: "PriceListID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPriceListProduct_PriceListProducts_PriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListProductProduct_PriceListProducts_ProductID",
                table: "PriceListProductProduct",
                column: "ProductID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
