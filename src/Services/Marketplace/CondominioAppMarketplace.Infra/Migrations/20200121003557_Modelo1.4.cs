using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class Modelo14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Cpf = table.Column<string>(maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: true),
                    Municipio = table.Column<string>(maxLength: 50, nullable: true),
                    ParceiroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_ParceiroId",
                table: "Vendedor",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
