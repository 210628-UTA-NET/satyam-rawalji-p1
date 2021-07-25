using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppDL.Migrations
{
    public partial class LineItemInInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inventories_LineItemId",
                table: "Inventories",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_LineItems_LineItemId",
                table: "Inventories",
                column: "LineItemId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_LineItems_LineItemId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_LineItemId",
                table: "Inventories");
        }
    }
}
