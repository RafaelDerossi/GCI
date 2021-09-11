using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations
{
    public partial class ArquivoAnexoEFotosNaAreaComum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtensaoDoArquivo",
                table: "AreasComuns",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivo",
                table: "AreasComuns",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "AreasComuns",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FotoDaAreaComum",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    AreaComumId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoDaAreaComum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoDaAreaComum_AreasComuns_AreaComumId",
                        column: x => x.AreaComumId,
                        principalTable: "AreasComuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Protocolo",
                table: "Reservas",
                column: "Protocolo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FotoDaAreaComum_AreaComumId",
                table: "FotoDaAreaComum",
                column: "AreaComumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoDaAreaComum");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_Protocolo",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ExtensaoDoArquivo",
                table: "AreasComuns");

            migrationBuilder.DropColumn(
                name: "NomeDoArquivo",
                table: "AreasComuns");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                table: "AreasComuns");
        }
    }
}
