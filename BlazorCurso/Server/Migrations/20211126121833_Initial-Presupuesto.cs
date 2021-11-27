using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCurso.Server.Migrations
{
    public partial class InitialPresupuesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    SubcategoriaId = table.Column<int>(type: "int", nullable: false),
                    ConceptoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => new { x.SubcategoriaId, x.ConceptoId });
                    table.ForeignKey(
                        name: "FK_Registro_Concepto_ConceptoId",
                        column: x => x.ConceptoId,
                        principalTable: "Concepto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registro_Subcategoria_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "Subcategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegsitroId = table.Column<int>(type: "int", nullable: false),
                    RegistroSubcategoriaId = table.Column<int>(type: "int", nullable: true),
                    RegistroConceptoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Registro_RegistroSubcategoriaId_RegistroConceptoId",
                        columns: x => new { x.RegistroSubcategoriaId, x.RegistroConceptoId },
                        principalTable: "Registro",
                        principalColumns: new[] { "SubcategoriaId", "ConceptoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_RegistroSubcategoriaId_RegistroConceptoId",
                table: "Movimiento",
                columns: new[] { "RegistroSubcategoriaId", "RegistroConceptoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_ConceptoId",
                table: "Registro",
                column: "ConceptoId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategoria_CategoriaId",
                table: "Subcategoria",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Concepto");

            migrationBuilder.DropTable(
                name: "Subcategoria");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
