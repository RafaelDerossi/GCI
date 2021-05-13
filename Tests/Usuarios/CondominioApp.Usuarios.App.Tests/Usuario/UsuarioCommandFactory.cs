using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static AdicionarUsuarioCommand CadastrarUsuarioCommandFactoy()
        {
            return new AdicionarUsuarioCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", "foto2.jpg", "fotoOriginal.jpg",
                 "874541213", "689.560.890-78", "(21) 99988-5241",
                 "(21) 99988-5241", "logradouro", "lt 30","S/N","","Bairro","Rio de Janeiro",
                 "RJ", new DateTime(1985, 05, 10));
        }

        public static AtualizarUsuarioCommand EditarUsuarioCommandFactoy()
        {
            return new AtualizarUsuarioCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "874541213", "689.560.890-78",
                 "foto.jpg", "original.jpg", "(21) 99988-5241", "(21) 99988-5241", "logradouro", "lt 30", "S/N", "",
                 "Bairro", "Rio de Janeiro", "RJ", new DateTime(1985, 05, 10));
        }


        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuario()
        {
            return CadastrarUsuarioCommandFactoy();
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioSemFoto()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetFoto("", "");

            return comando;
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioSemNome()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetNome("");

            return comando;
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioSemEmail()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetEmail("");

            return comando;
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioComEmailInvalido()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetEmail("alexandre@techdog");

            return comando;
            
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioSemDataDeNascimento()
        {
            try
            {
                return new AdicionarUsuarioCommand
                 (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", "foto2.jpg",
                 "fotoOriginal.jpg", "874541213", "689.560.890-78", "(21) 99988-5241", "(21) 99988-5241", "logradouro", "lt 30", "S/N", "", "Bairro",
                 "Rio de Janeiro", "RJ");
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static AdicionarUsuarioCommand CriarComandoCadastroDeUsuarioCPFInvalido()
        {
            var comando = CadastrarUsuarioCommandFactoy();
            comando.SetCpf("689.560.890-77");

            return comando;
           
        }


        public static AtualizarUsuarioCommand CriarComandoEdicaoDeUsuario()
        {
            return EditarUsuarioCommandFactoy();
        }
    }
}