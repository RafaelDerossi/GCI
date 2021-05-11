using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations
{
    public partial class MoradorFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobile_Usuarios_UsuarioId",
                table: "Mobile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mobile",
                table: "Mobile");

            migrationBuilder.DropColumn(
                name: "Atribuicao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Permissao",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Mobile",
                newName: "Mobiles");

            migrationBuilder.RenameIndex(
                name: "IX_Mobile_UsuarioId",
                table: "Mobiles",
                newName: "IX_Mobiles_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Versao",
                table: "Mobiles",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Mobiles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Plataforma",
                table: "Mobiles",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Mobiles",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileId",
                table: "Mobiles",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceKey",
                table: "Mobiles",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mobiles",
                table: "Mobiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    Atribuicao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Funcao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Permissao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    Proprietario = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Principal = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradores", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Usuarios_UsuarioId",
                table: "Mobiles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Usuarios_UsuarioId",
                table: "Mobiles");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Moradores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mobiles",
                table: "Mobiles");

            migrationBuilder.RenameTable(
                name: "Mobiles",
                newName: "Mobile");

            migrationBuilder.RenameIndex(
                name: "IX_Mobiles_UsuarioId",
                table: "Mobile",
                newName: "IX_Mobile_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Atribuicao",
                table: "Usuarios",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Usuarios",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Permissao",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Versao",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Mobile",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Plataforma",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileId",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceKey",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mobile",
                table: "Mobile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobile_Usuarios_UsuarioId",
                table: "Mobile",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
