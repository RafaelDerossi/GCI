using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioApp.Usuarios.App.Migrations.UsuarioQueryContextDBMigrations
{
    public partial class MoradorEFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuncionariosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Rg = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TpUsuario = table.Column<string>(nullable: true),
                    Atribuicao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Funcao = table.Column<string>(type: "varchar(200)", nullable: true),
                    SindicoProfissional = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoradoresFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false),
                    NumeroUnidade = table.Column<string>(nullable: true),
                    AndarUnidade = table.Column<string>(nullable: true),
                    GrupoUnidade = table.Column<string>(nullable: true),
                    CondominioId = table.Column<Guid>(nullable: false),
                    NomeCondominio = table.Column<string>(nullable: true),
                    Proprietario = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Principal = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Rg = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TpUsuario = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoradoresFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosFlat");

            migrationBuilder.DropTable(
                name: "MoradoresFlat");
        }
    }
}
