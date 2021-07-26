using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppDL.Migrations
{
    public partial class AddEverythingToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LineItemId",
                table: "Orders",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_LineItems_LineItemId",
                table: "Orders",
                column: "LineItemId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_LineItems_LineItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LineItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "Orders");
        }
    }
}
