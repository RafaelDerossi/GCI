using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations.PrincipalQueryContextDBMigrations
{
    public partial class AjusteLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CondominioLogoMarca",
                table: "UnidadesFlat",
                newName: "CondominioNomeLogo");

            migrationBuilder.RenameColumn(
                name: "CondominioLogoMarca",
                table: "GruposFlat",
                newName: "CondominioNomeLogo");

            migrationBuilder.AlterColumn<string>(
                name: "CondominioCnpj",
                table: "UnidadesFlat",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Andar",
                table: "UnidadesFlat",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "CondominioCnpj",
                table: "GruposFlat",
                type: "varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(18)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "CondominiosFlat",
                type: "varchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "CondominiosFlat",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CondominioNomeLogo",
                table: "UnidadesFlat",
                newName: "CondominioLogoMarca");

            migrationBuilder.RenameColumn(
                name: "CondominioNomeLogo",
                table: "GruposFlat",
                newName: "CondominioLogoMarca");

            migrationBuilder.AlterColumn<string>(
                name: "CondominioCnpj",
                table: "UnidadesFlat",
                type: "varchar(18)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Andar",
                table: "UnidadesFlat",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "CondominioCnpj",
                table: "GruposFlat",
                type: "varchar(18)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "CondominiosFlat",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "CondominiosFlat",
                type: "varchar(18)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);
        }
    }
}
