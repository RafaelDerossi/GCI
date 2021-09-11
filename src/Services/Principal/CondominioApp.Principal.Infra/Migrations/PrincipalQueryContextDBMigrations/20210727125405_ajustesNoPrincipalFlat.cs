using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class ajustesNoPrincipalFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chat",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ChatMorador",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Classificado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ClassificadoMorador",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Correspondencia",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaNaPortaria",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "LimiteTempoReserva",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "LinkContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Mural",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "MuralMorador",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Ocorrencia",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "OcorrenciaMorador",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Portaria",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "PortariaMorador",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "Reserva",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ReservaNaPortaria",
                table: "CondominiosFlat");

            migrationBuilder.RenameColumn(
                name: "LogoMarca",
                table: "CondominiosFlat",
                newName: "NomeOriginalArquivoLogo");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPlano",
                table: "CondominiosFlat",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CadastroDeVeiculoPeloMoradorAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChatAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ChatParaMoradorAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoParaMoradorAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaNaPortariaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralParaMoradorAtivado",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoContrato",
                table: "CondominiosFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoLogo",
                table: "CondominiosFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginalArquivoContrato",
                table: "CondominiosFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaParaMoradorAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaParaMoradorAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeUnidadesContratadas",
                table: "CondominiosFlat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ReservaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ReservaNaPortariaAtivada",
                table: "CondominiosFlat",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastroDeVeiculoPeloMoradorAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ChatAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ChatParaMoradorAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ClassificadoAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ClassificadoParaMoradorAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "CorrespondenciaNaPortariaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "MuralAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "MuralParaMoradorAtivado",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "NomeArquivoContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "NomeArquivoLogo",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "NomeOriginalArquivoContrato",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "OcorrenciaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "OcorrenciaParaMoradorAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "PortariaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "PortariaParaMoradorAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "QuantidadeDeUnidadesContratadas",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ReservaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.DropColumn(
                name: "ReservaNaPortariaAtivada",
                table: "CondominiosFlat");

            migrationBuilder.RenameColumn(
                name: "NomeOriginalArquivoLogo",
                table: "CondominiosFlat",
                newName: "LogoMarca");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPlano",
                table: "CondominiosFlat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Chat",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ChatMorador",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Classificado",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ClassificadoMorador",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Correspondencia",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "CorrespondenciaNaPortaria",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "LimiteTempoReserva",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<string>(
                name: "LinkContrato",
                table: "CondominiosFlat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Mural",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "MuralMorador",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Ocorrencia",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaMorador",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Portaria",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "PortariaMorador",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "Reserva",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "ReservaNaPortaria",
                table: "CondominiosFlat",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }
    }
}
