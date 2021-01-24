using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryHouse.Migrations
{
    public partial class Faultrecovery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingredientid",
                schema: "BH",
                table: "Ingredient",
                newName: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientId",
                schema: "BH",
                table: "Ingredient",
                newName: "Ingredientid");
        }
    }
}
