﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceList.WebApplication.Migrations
{
    public partial class Complete5Tablesv13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPriceListProduct_PriceLists_PriceListsPriceListID",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceListProductProduct_Products_ProductsProductID",
                table: "PriceListProductProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct");

            migrationBuilder.DropIndex(
                name: "IX_PriceListPriceListProduct_PriceListsPriceListID",
                table: "PriceListPriceListProduct");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceListPriceListProduct",
                table: "PriceListPriceListProduct",
                columns: new[] { "PriceListProductsPriceListLineID", "PriceListsPriceListID" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPriceListProduct_PriceListsPriceListID",
                table: "PriceListPriceListProduct",
                column: "PriceListsPriceListID");

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
        }
    }
}
