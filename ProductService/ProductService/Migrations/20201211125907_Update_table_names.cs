using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class Update_table_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Ivas_IdIva",
                table: "Articoli");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcodes_Articoli_CodArt",
                table: "Barcodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Articoli_CodArt",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ivas",
                table: "Ivas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes");

            migrationBuilder.RenameTable(
                name: "Ivas",
                newName: "Iva");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredienti");

            migrationBuilder.RenameTable(
                name: "Barcodes",
                newName: "Barcode");

            migrationBuilder.RenameIndex(
                name: "IX_Barcodes_CodArt",
                table: "Barcode",
                newName: "IX_Barcode_CodArt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iva",
                table: "Iva",
                column: "IdIva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredienti",
                table: "Ingredienti",
                column: "CodArt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barcode",
                table: "Barcode",
                column: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Iva_IdIva",
                table: "Articoli",
                column: "IdIva",
                principalTable: "Iva",
                principalColumn: "IdIva",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredienti_Articoli_CodArt",
                table: "Ingredienti",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articoli_Iva_IdIva",
                table: "Articoli");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_Articoli_CodArt",
                table: "Barcode");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredienti_Articoli_CodArt",
                table: "Ingredienti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iva",
                table: "Iva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredienti",
                table: "Ingredienti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barcode",
                table: "Barcode");

            migrationBuilder.RenameTable(
                name: "Iva",
                newName: "Ivas");

            migrationBuilder.RenameTable(
                name: "Ingredienti",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Barcode",
                newName: "Barcodes");

            migrationBuilder.RenameIndex(
                name: "IX_Barcode_CodArt",
                table: "Barcodes",
                newName: "IX_Barcodes_CodArt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ivas",
                table: "Ivas",
                column: "IdIva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "CodArt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes",
                column: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Articoli_Ivas_IdIva",
                table: "Articoli",
                column: "IdIva",
                principalTable: "Ivas",
                principalColumn: "IdIva",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcodes_Articoli_CodArt",
                table: "Barcodes",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Articoli_CodArt",
                table: "Ingredients",
                column: "CodArt",
                principalTable: "Articoli",
                principalColumn: "CodArt",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
