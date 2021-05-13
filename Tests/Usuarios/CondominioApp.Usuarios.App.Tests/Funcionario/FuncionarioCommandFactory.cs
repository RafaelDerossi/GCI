using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class FuncionarioCommandFactory
    {
        public static AdicionarFuncionarioCommand CadastrarFuncionarioSindicoCommandFactoy()
        {
            return new AdicionarFuncionarioCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", "Sindico",
                "Sindico", Permissao.ADMIN);
        }
        public static AdicionarFuncionarioCommand CadastrarFuncionarioPorteiroCommandFactoy()
        {
            return new AdicionarFuncionarioCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", "Porteiro",
                "Porteiro", Permissao.USUARIO);
        }

         public static AtualizarFuncionarioCommand EditarFuncionarioCommandFactoy()
        {
            return new AtualizarFuncionarioCommand
                (Guid.NewGuid(), "Porteiro", "Porteiro", Permissao.USUARIO);
        }


        public static AdicionarFuncionarioCommand CriarComandoCadastroDeSindico()
        {
            return CadastrarFuncionarioSindicoCommandFactoy();
        }

        public static AdicionarFuncionarioCommand CriarComandoCadastroDePorteiro()
        {
            return CadastrarFuncionarioPorteiroCommandFactoy();
        }


        public static AtualizarFuncionarioCommand CriarComandoEdicaoDeFuncionario()
        {
            return EditarFuncionarioCommandFactoy();
        }

    }
}