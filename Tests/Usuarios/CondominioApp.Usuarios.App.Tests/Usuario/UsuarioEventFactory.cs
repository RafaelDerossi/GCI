using System;
using CondominioApp.Usuarios.App.Aplication.Events;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioEventFactory
    {
        public static MoradorCadastradoEvent MoradorCadastradoEventFactory()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "foto2.jpg", Guid.NewGuid(), Guid.NewGuid(),
                true, true, new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMorador()
        {
            return MoradorCadastradoEventFactory();
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemFoto()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetFoto("");
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoadastroDeMoradorSemNome()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetNome("");
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemEmail()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetEmail("");
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemDataDeNascimento()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br",
                "874541213", "689.560.890-78", "(21) 99988-5241", "foto2.jpg", Guid.NewGuid(), Guid.NewGuid(),
                true, true);
        }
    }
}