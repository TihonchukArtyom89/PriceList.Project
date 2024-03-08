using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_PriceListProducts_PriceListProductPriceListLineID",
                table: "PriceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PriceListProducts_PriceListProductPriceListLineID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceListProductPriceListLineID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_PriceListProductPriceListLineID",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "PriceListProductPriceListLineID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceListProductPriceListLineID",
                table: "PriceLists");

            migrationBuilder.CreateTable(
                name: "PriceListPriceListProduct",
                columns: table => new
                {
                    PriceListID = table.Column<long>(type: "bigint", nullable: false),
                    PriceListsPriceListID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListPriceListProduct", x => new { x.PriceListID, x.PriceListsPriceListID });
                    table.ForeignKey(
                        name: "FK_PriceListPriceListProduct_PriceListProducts_PriceListID",
                        column: x => x.PriceListID,
                        principalTable: "PriceListProducts",
                        principalColumn: "PriceListLineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListPriceListProduct_PriceLists_PriceListsPriceListID",
                        column: x => x.PriceListsPriceListID,
                        principalTable: "PriceLists",
                        principalColumn: "PriceListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListProductProduct",
                columns: table => new
                {
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProductID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListProductProduct", x => new { x.ProductID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_PriceListProductProduct_PriceListProducts_ProductID",
                        column: x => x.ProductID,
                        principalTable: "PriceListProducts",
                        principalColumn: "PriceListLineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListProductProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPriceListProduct_PriceListsPriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListsPriceListID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListProductProduct_ProductsProductID",
                table: "PriceListProductProduct",
                column: "ProductsProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceListPriceListProduct");

            migrationBuilder.DropTable(
                name: "PriceListProductProduct");

            migrationBuilder.AddColumn<long>(
                name: "PriceListProductPriceListLineID",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PriceListProductPriceListLineID",
                table: "PriceLists",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceListProductPriceListLineID",
                table: "Products",
                column: "PriceListProductPriceListLineID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_PriceListProductPriceListLineID",
                table: "PriceLists",
                column: "PriceListProductPriceListLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_PriceListProducts_PriceListProductPriceListLineID",
                table: "PriceLists",
                column: "PriceListProductPriceListLineID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PriceListProducts_PriceListProductPriceListLineID",
                table: "Products",
                column: "PriceListProductPriceListLineID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID");
        }
    }
}
