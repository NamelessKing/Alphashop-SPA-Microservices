using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamAssort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamAssort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ivas",
                columns: table => new
                {
                    IdIva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(nullable: true),
                    Aliquota = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ivas", x => x.IdIva);
                });

            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    CodArt = table.Column<string>(maxLength: 30, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 80, nullable: true),
                    Um = table.Column<string>(nullable: true),
                    CodStat = table.Column<string>(nullable: true),
                    PzCart = table.Column<short>(nullable: true),
                    PesoNetto = table.Column<double>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: true),
                    IdIva = table.Column<int>(nullable: true),
                    IDFAMASS = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.CodArt);
                    table.ForeignKey(
                        name: "FK_Articoli_FamAssort_IDFAMASS",
                        column: x => x.IDFAMASS,
                        principalTable: "FamAssort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articoli_Ivas_IdIva",
                        column: x => x.IdIva,
                        principalTable: "Ivas",
                        principalColumn: "IdIva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Barcode = table.Column<string>(maxLength: 13, nullable: false),
                    IdTipoArt = table.Column<string>(nullable: false),
                    CodArt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_Barcodes_Articoli_CodArt",
                        column: x => x.CodArt,
                        principalTable: "Articoli",
                        principalColumn: "CodArt",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    CodArt = table.Column<string>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.CodArt);
                    table.ForeignKey(
                        name: "FK_Ingredients_Articoli_CodArt",
                        column: x => x.CodArt,
                        principalTable: "Articoli",
                        principalColumn: "CodArt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_IDFAMASS",
                table: "Articoli",
                column: "IDFAMASS");

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_IdIva",
                table: "Articoli",
                column: "IdIva");

            migrationBuilder.CreateIndex(
                name: "IX_Barcodes_CodArt",
                table: "Barcodes",
                column: "CodArt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Articoli");

            migrationBuilder.DropTable(
                name: "FamAssort");

            migrationBuilder.DropTable(
                name: "Ivas");
        }
    }
}
