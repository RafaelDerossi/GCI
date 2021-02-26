using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static CadastrarUsuarioCommand CriarComandoCadastroDeMorador()
        {
            return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "foto2.jpg", "fotoOriginal.jpg",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemFoto()
        {
            return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemNome()
        {
            return new CadastrarUsuarioCommand(Guid.NewGuid(), "", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemEmail()
        {
            return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorComEmailInvalido()
        {
            return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorSemDataDeNascimento()
        {
            try
            {
                return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
              "874541213", "689.560.890-78", "(21) 99988-5241", "", "");
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static CadastrarUsuarioCommand CriarComandoCadastroDeMoradorCPFInvalido()
        {
            try
            {
                return new CadastrarUsuarioCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                               "874541213", "689.560.890-77", "(21) 99988-5241", "foto2.jpg", "fotoOriginal.jpg",
                               new DateTime(1985, 05, 10));
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}