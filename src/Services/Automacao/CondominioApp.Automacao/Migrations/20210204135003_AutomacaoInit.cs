using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Automacao.App.Migrations
{
    public partial class AutomacaoInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondominiosCredenciais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Senha = table.Column<string>(type: "varchar(200)", nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    TipoApiAutomacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominiosCredenciais", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondominiosCredenciais");
        }
    }
}
