using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Principal.Infra.Migrations
{
    public partial class EnderecoNoCondominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Condominios",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Condominios",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Condominios",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Condominios",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Condominios",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Condominios",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Condominios",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Condominios");
        }
    }
}
