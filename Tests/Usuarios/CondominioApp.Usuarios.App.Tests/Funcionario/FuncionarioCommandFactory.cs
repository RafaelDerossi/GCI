using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class FuncionarioCommandFactory
    {
        public static CadastrarFuncionarioCommand CadastrarFuncionarioSindicoCommandFactoy()
        {
            return new CadastrarFuncionarioCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", "Sindico",
                "Sindico", Permissao.ADMIN);
        }
        public static CadastrarFuncionarioCommand CadastrarFuncionarioPorteiroCommandFactoy()
        {
            return new CadastrarFuncionarioCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", "Porteiro",
                "Porteiro", Permissao.USUARIO);
        }

         public static EditarFuncionarioCommand EditarFuncionarioCommandFactoy()
        {
            return new EditarFuncionarioCommand
                (Guid.NewGuid(), "Porteiro", "Porteiro", Permissao.USUARIO);
        }


        public static CadastrarFuncionarioCommand CriarComandoCadastroDeSindico()
        {
            return CadastrarFuncionarioSindicoCommandFactoy();
        }

        public static CadastrarFuncionarioCommand CriarComandoCadastroDePorteiro()
        {
            return CadastrarFuncionarioPorteiroCommandFactoy();
        }


        public static EditarFuncionarioCommand CriarComandoEdicaoDeFuncionario()
        {
            return EditarFuncionarioCommandFactoy();
        }

    }
}