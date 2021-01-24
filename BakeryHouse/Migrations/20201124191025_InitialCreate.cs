using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryHouse.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BH");

            migrationBuilder.CreateTable(
                name: "Afhaalpunt",
                schema: "BH",
                columns: table => new
                {
                    AfhaalpuntId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    stad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afhaalpunt", x => x.AfhaalpuntId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "BH",
                columns: table => new
                {
                    Ingredientid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(nullable: true),
                    Allergeen = table.Column<string>(nullable: true),
                    Voorraad = table.Column<int>(nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Ingredientid);
                });

            migrationBuilder.CreateTable(
                name: "Klant",
                schema: "BH",
                columns: table => new
                {
                    KlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefoon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.KlantId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "BH",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "BH",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false),
                    AfhaalpuntId = table.Column<int>(nullable: false),
                    Orderdatum = table.Column<DateTime>(nullable: false),
                    LeverDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Afhaalpunt_AfhaalpuntId",
                        column: x => x.AfhaalpuntId,
                        principalSchema: "BH",
                        principalTable: "Afhaalpunt",
                        principalColumn: "AfhaalpuntId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Klant_KlantId",
                        column: x => x.KlantId,
                        principalSchema: "BH",
                        principalTable: "Klant",
                        principalColumn: "KlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productregel",
                schema: "BH",
                columns: table => new
                {
                    ProductregelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productregel", x => x.ProductregelId);
                    table.ForeignKey(
                        name: "FK_Productregel_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "BH",
                        principalTable: "Ingredient",
                        principalColumn: "Ingredientid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productregel_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "BH",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderlijn",
                schema: "BH",
                columns: table => new
                {
                    OrderlijnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderlijn", x => x.OrderlijnId);
                    table.ForeignKey(
                        name: "FK_Orderlijn_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "BH",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderlijn_Product_Productid",
                        column: x => x.Productid,
                        principalSchema: "BH",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AfhaalpuntId",
                schema: "BH",
                table: "Order",
                column: "AfhaalpuntId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_KlantId",
                schema: "BH",
                table: "Order",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_OrderId",
                schema: "BH",
                table: "Orderlijn",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_Productid",
                schema: "BH",
                table: "Orderlijn",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_Productregel_IngredientId",
                schema: "BH",
                table: "Productregel",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Productregel_ProductId",
                schema: "BH",
                table: "Productregel",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderlijn",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Productregel",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Afhaalpunt",
                schema: "BH");

            migrationBuilder.DropTable(
                name: "Klant",
                schema: "BH");
        }
    }
}
