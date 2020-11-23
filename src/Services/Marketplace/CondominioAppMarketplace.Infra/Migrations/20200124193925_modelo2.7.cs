using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAppMarketplace.Infra.Migrations
{
    public partial class modelo27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EspecificacaoTecnica",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Parceiro",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CondominioId",
                table: "ItemDeVenda",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PorcentagemDeDesconto",
                table: "ItemDeVenda",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EspecificacaoTecnica",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Parceiro");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "ItemDeVenda");

            migrationBuilder.DropColumn(
                name: "PorcentagemDeDesconto",
                table: "ItemDeVenda");
        }
    }
}
