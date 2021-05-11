using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations
{
    public partial class VeiculoInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cor = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeiculosCondominios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    VeiculoId = table.Column<Guid>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosCondominios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculosCondominios_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosCondominios_VeiculoId",
                table: "VeiculosCondominios",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculosCondominios");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
