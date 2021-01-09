using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class Article_Barcode_added_OnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
