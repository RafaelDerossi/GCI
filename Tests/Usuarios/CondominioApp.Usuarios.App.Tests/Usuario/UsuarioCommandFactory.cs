using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static CadastrarUsuarioCommand CadastrarUsuarioCommandFactoy()
        {
            return new CadastrarUsuarioCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", "foto2.jpg", "fotoOriginal.jpg",
                 "874541213", "689.560.890-78", "(21) 99988-5241",
                 "(21) 99988-5241", "logradouro", "lt 30","S/N","","Bairro","Rio de Janeiro",
                 "RJ", new DateTime(1985, 05, 10));
        }

        public static EditarUsuarioCommand EditarUsuarioCommandFactoy()
        {
            return new EditarUsuarioCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "874541213", "689.560.890-78",
                 "foto.jpg", "original.jpg", "(21) 99988-5241", "(21) 99988-5241", "logradouro", "lt 30", "S/N", "",
                 "Bairro", "Rio de Janeiro", "RJ", new DateTime(1985, 05, 10));
        }


        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuario()
        {
            return CadastrarUsuarioCommandFactoy();
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioSemFoto()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetFoto("", "");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioSemNome()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetNome("");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioSemEmail()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetEmail("");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioComEmailInvalido()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetEmail("alexandre@techdog");

            return comando;
            
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioSemDataDeNascimento()
        {
            try
            {
                return new CadastrarUsuarioCommand
                 (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", "foto2.jpg",
                 "fotoOriginal.jpg", "874541213", "689.560.890-78", "(21) 99988-5241", "(21) 99988-5241", "logradouro", "lt 30", "S/N", "", "Bairro",
                 "Rio de Janeiro", "RJ");
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeUsuarioCPFInvalido()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetCpf("689.560.890-77");

            return comando;
           
        }


        public static EditarUsuarioCommand CriarComandoEdicaoDeUsuario()
        {
            return EditarUsuarioCommandFactoy();
        }
    }
}