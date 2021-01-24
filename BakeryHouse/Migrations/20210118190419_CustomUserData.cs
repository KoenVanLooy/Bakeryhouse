using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryHouse.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "BH",
                table: "Klant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klant_UserId",
                schema: "BH",
                table: "Klant",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Klant_AspNetUsers_UserId",
                schema: "BH",
                table: "Klant",
                column: "UserId",
                principalSchema: "BH",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klant_AspNetUsers_UserId",
                schema: "BH",
                table: "Klant");

            migrationBuilder.DropIndex(
                name: "IX_Klant_UserId",
                schema: "BH",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "BH",
                table: "Klant");
        }
    }
}
