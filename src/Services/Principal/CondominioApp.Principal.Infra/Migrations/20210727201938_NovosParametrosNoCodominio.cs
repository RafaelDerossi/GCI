using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations
{
    public partial class NovosParametrosNoCodominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Unidades",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Condominios",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Condominios",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutomacaoAtivada",
                table: "Condominios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ControleDeAcessoAtivado",
                table: "Condominios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnqueteAtivada",
                table: "Condominios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OrcamentoAtivado",
                table: "Condominios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TarefaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutomacaoAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ControleDeAcessoAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "EnqueteAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "OrcamentoAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "TarefaAtivada",
                table: "Condominios");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Unidades",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Condominios",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Condominios",
                type: "varchar(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}
