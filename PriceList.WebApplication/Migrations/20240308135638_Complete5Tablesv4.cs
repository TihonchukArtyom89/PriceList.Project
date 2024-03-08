using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionalParameters",
                columns: table => new
                {
                    OptionalParameterID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionalParameterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionalParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalParameters", x => x.OptionalParameterID);
                });

            migrationBuilder.CreateTable(
                name: "PriceListOptionalParameters",
                columns: table => new
                {
                    OptionalParameterEntryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionalParameterID = table.Column<long>(type: "bigint", nullable: false),
                    OptionalParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceListLineID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListOptionalParameters", x => x.OptionalParameterEntryID);
                });

            migrationBuilder.CreateTable(
                name: "PriceListProducts",
                columns: table => new
                {
                    PriceListLineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListProducts", x => x.PriceListLineID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionalParameters");

            migrationBuilder.DropTable(
                name: "PriceListOptionalParameters");

            migrationBuilder.DropTable(
                name: "PriceListProducts");
        }
    }
}
