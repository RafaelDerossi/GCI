using System;
using CondominioApp.Usuarios.App.Aplication.Events;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioEventFactory
    {
        public static MoradorCadastradoEvent CriarEventoCadastroDeMorador()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "foto2.jpg", "fotoOriginal.jpg",
                new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemFoto()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoadastroDeMoradorSemNome()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemEmail()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Alexandre", "Nascimento", "",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "",
                new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemDataDeNascimento()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Alexandre", "Nascimento", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "", "");
        }
    }
}