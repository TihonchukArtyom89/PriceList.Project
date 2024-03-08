using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_PriceListProducts_PriceListID",
                table: "PriceLists");

            migrationBuilder.AddColumn<long>(
                name: "PriceListProductPriceListLineID",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PriceListID",
                table: "PriceLists",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "PriceListProductPriceListLineID",
                table: "PriceLists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PriceListID",
                table: "PriceListProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PriceListID",
                table: "PriceListProducts");

            migrationBuilder.AlterColumn<long>(
                name: "PriceListID",
                table: "PriceLists",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_PriceListProducts_PriceListID",
                table: "PriceLists",
                column: "PriceListID",
                principalTable: "PriceListProducts",
                principalColumn: "PriceListLineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
