using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations
{
    public partial class InicialUsuarioDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Rg = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    NomeDoArquivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TpUsuario = table.Column<int>(nullable: false),
                    Permissao = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Atribuicao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Funcao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    UltimoLogin = table.Column<DateTime>(nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true),
                    Municipio = table.Column<string>(maxLength: 200, nullable: true),
                    SindicoProfissional = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    DeviceKey = table.Column<string>(nullable: true),
                    MobileId = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Plataforma = table.Column<string>(nullable: true),
                    Versao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobile_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_UsuarioId",
                table: "Mobile",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
