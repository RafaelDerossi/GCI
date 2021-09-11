using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations
{
    public partial class ajustesNoPrincipal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "Chat",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ChatMorador",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Classificado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ClassificadoMorador",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Correspondencia",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaNaPortaria",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "LimiteTempoReserva",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Mural",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "MuralMorador",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Ocorrencia",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "OcorrenciaMorador",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Portaria",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "PortariaMorador",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Reserva",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ReservaNaPortaria",
                table: "Condominios");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Contratos",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeUnidadesContratada",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtensaoDoArquivo",
                table: "Contratos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDoArquivo",
                table: "Contratos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "Contratos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CadastroDeVeiculoPeloMoradorAtivado",
                table: "Condominios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChatAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ChatParaMoradorAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoParaMoradorAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaNaPortariaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralParaMoradorAtivado",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaParaMoradorAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaParaMoradorAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ReservaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ReservaNaPortariaAtivada",
                table: "Condominios",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDeUnidadesContratada",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ExtensaoDoArquivo",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "NomeDoArquivo",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "CadastroDeVeiculoPeloMoradorAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ChatAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ChatParaMoradorAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ClassificadoAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ClassificadoParaMoradorAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaNaPortariaAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "MuralAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "MuralParaMoradorAtivado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "OcorrenciaAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "OcorrenciaParaMoradorAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "PortariaAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "PortariaParaMoradorAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ReservaAtivada",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ReservaNaPortariaAtivada",
                table: "Condominios");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Chat",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ChatMorador",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Classificado",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoMorador",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Correspondencia",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaNaPortaria",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "LimiteTempoReserva",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Mural",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralMorador",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Ocorrencia",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaMorador",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Portaria",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaMorador",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Reserva",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ReservaNaPortaria",
                table: "Condominios",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }
    }
}
