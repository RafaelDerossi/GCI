using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static CadastrarUsuarioCommand CadastrarMoradorCommandFactoy()
        {
            return new CadastrarUsuarioCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", Guid.NewGuid(), Guid.NewGuid(),
                "foto2.jpg", "fotoOriginal.jpg", "874541213", "689.560.890-78", "(21) 99988-5241", true, true,
                null, null, new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMorador()
        {
            return CadastrarMoradorCommandFactoy();
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemFoto()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetFoto("", "");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemNome()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetNome("");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemEmail()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetEmail("");

            return comando;
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorComEmailInvalido()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetEmail("alexandre@techdog");

            return comando;
            
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemDataDeNascimento()
        {
            try
            {
                return new CadastrarUsuarioCommand
                 (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", Guid.NewGuid(), Guid.NewGuid(),
                 "foto2.jpg", "fotoOriginal.jpg", "874541213", "689.560.890-78", "(21) 99988-5241", true, true,
                 null, null);
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorCPFInvalido()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetCpf("689.560.890-77");

            return comando;
           
        }
    }
}