using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_PriceListProducts_PriceListID",
                table: "PriceLists");

            migrationBuilder.AlterColumn<long>(
                name: "PriceListID",
                table: "PriceLists",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "PriceListID",
                table: "PriceListProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
