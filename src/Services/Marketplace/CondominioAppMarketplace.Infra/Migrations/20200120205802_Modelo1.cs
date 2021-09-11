using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class Modelo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: true),
                    LogoMarca = table.Column<string>(nullable: true),
                    Login = table.Column<string>(maxLength: 50, nullable: true),
                    Token = table.Column<Guid>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 50, nullable: true),
                    Senha = table.Column<string>(maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: true),
                    Municipio = table.Column<string>(maxLength: 50, nullable: true),
                    ContratoDataDeInicio = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ContratoDataDeRenovacao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ContratoDescricao = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    ParceiroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominio_Parceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_ParceiroId",
                table: "Condominio",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "Parceiro");
        }
    }
}
