using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Automacao.App.Migrations
{
    public partial class DispositivosWebkooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispositivoWebhook",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    UrlLigar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    UrlDesligar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositivoWebhook", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispositivoWebhook");
        }
    }
}
