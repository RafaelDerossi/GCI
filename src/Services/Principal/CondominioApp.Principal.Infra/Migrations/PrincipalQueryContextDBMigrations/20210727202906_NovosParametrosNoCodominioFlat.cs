using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class NovosParametrosNoCodominioFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutomacaoAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ControleDeAcessoAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnqueteAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OrcamentoAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TarefaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutomacaoAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ControleDeAcessoAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "EnqueteAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "OrcamentoAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "TarefaAtivada",
                table: "CondominiosFlat");
        }
    }
}
