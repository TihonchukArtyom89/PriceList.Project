using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPriceListProduct_PriceLists_PriceListID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProductProduct_Products_ProductID",
                table: "PriceListProductProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropIndex(
                name: "IX_PriceListPriceListProduct_PriceListProductsPriceListLineID",
                table: "PriceListPriceListProduct");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "PriceListProductProduct",
                newName: "ProductsProductID");

            migrationBuilder.RenameIndex(
                name: "IX_PriceListProductProduct_ProductID",
                table: "PriceListProductProduct",
                newName: "IX_PriceListProductProduct_ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "PriceListID",
                table: "PriceListPriceListProduct",
                newName: "PriceListsPriceListID");

            migrationBuilder.AddColumn<long>(
                name: "PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct",
                columns: new[] { "PriceListProductsPriceListLineID", "PriceListsPriceListID" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListProducts_PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts",
                column: "PriceListOptionalParametersOptionalParameterEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPriceListProduct_PriceListsPriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListsPriceListID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListOptionalParameters_OptionalParameterID",
                table: "PriceListOptionalParameters",
                column: "OptionalParameterID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListOptionalParameters_OptionalParameters_OptionalParameterID",
                table: "PriceListOptionalParameters",
                column: "OptionalParameterID",
                principalTable: "OptionalParameters",
                principalColumn: "OptionalParameterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPriceListProduct_PriceLists_PriceListsPriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListsPriceListID",
                principalTable: "PriceLists",
                principalColumn: "PriceListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListProductProduct_Products_ProductsProductID",
                table: "PriceListProductProduct",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListProducts_PriceListOptionalParameters_PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts",
                column: "PriceListOptionalParametersOptionalParameterEntryID",
                principalTable: "PriceListOptionalParameters",
                principalColumn: "OptionalParameterEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListOptionalParameters_OptionalParameters_OptionalParameterID",
                table: "PriceListOptionalParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPriceListProduct_PriceLists_PriceListsPriceListID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProductProduct_Products_ProductsProductID",
                table: "PriceListProductProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProducts_PriceListOptionalParameters_PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts");

            migrationBuilder.DropIndex(
                name: "IX_PriceListProducts_PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropIndex(
                name: "IX_PriceListPriceListProduct_PriceListsPriceListID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropIndex(
                name: "IX_PriceListOptionalParameters_OptionalParameterID",
                table: "PriceListOptionalParameters");

            migrationBuilder.DropColumn(
                name: "PriceListOptionalParametersOptionalParameterEntryID",
                table: "PriceListProducts");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "PriceListProductProduct",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_PriceListProductProduct_ProductsProductID",
                table: "PriceListProductProduct",
                newName: "IX_PriceListProductProduct_ProductID");

            migrationBuilder.RenameColumn(
                name: "PriceListsPriceListID",
                table: "PriceListPriceListProduct",
                newName: "PriceListID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct",
                columns: new[] { "PriceListID", "PriceListProductsPriceListLineID" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPriceListProduct_PriceListProductsPriceListLineID",
                table: "PriceListPriceListProduct",
                column: "PriceListProductsPriceListLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPriceListProduct_PriceLists_PriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListID",
                principalTable: "PriceLists",
                principalColumn: "PriceListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListProductProduct_Products_ProductID",
                table: "PriceListProductProduct",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
