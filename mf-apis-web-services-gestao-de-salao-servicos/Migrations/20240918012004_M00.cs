using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mf_apis_web_services_gestao_de_salao_servicos.Migrations
{
    /// <inheritdoc />
    public partial class M00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicoCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicoSubCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicoCategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoSubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoSubCategorias_ServicoCategorias_ServicoCategoriaId",
                        column: x => x.ServicoCategoriaId,
                        principalTable: "ServicoCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicoSubCategorias_ServicoCategoriaId",
                table: "ServicoSubCategorias",
                column: "ServicoCategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicoSubCategorias");

            migrationBuilder.DropTable(
                name: "ServicoCategorias");
        }
    }
}
