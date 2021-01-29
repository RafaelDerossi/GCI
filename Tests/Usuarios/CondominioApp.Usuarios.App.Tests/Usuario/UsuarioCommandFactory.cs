using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static CadastrarMoradorCommand CriarComandoCadastroDeMorador()
        {
            return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "foto2.jpg", "fotoOriginal.jpg",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemFoto()
        {
            return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemNome()
        {
            return new CadastrarMoradorCommand(Guid.NewGuid(), "", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemEmail()
        {
            return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorComEmailInvalido()
        {
            return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemDataDeNascimento()
        {
            try
            {
                return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
              "874541213", "689.560.890-78", "(21) 99988-5241", "", "");
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorCPFInvalido()
        {
            try
            {
                return new CadastrarMoradorCommand(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
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