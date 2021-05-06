using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    public partial class HistoricoReservaFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoReservaFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    ReservaId = table.Column<Guid>(nullable: false),
                    Acao = table.Column<int>(nullable: false),
                    AutorId = table.Column<Guid>(nullable: false),
                    NomeAutorAcao = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDoAutor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Origem = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoReservaFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoReservaFlat");
        }
    }
}
