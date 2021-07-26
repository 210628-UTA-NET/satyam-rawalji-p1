using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppDL.Migrations
{
    public partial class StoreFrontToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreFrontId",
                table: "Inventories",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_StoreFronts_StoreFrontId",
                table: "Inventories",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_StoreFronts_StoreFrontId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreFrontId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "Inventories");
        }
    }
}
