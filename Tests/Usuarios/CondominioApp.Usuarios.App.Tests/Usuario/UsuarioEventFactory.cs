using System;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioEventFactory
    {
        public static MoradorCadastradoEvent MoradorCadastradoEventFactory()
        {
            return new MoradorCadastradoEvent
                (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Nome condominio", Guid.NewGuid(), "101", "1", "Bloco A",
                 true, true);
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMorador()
        {
            return MoradorCadastradoEventFactory();
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemFoto()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetFoto(new Foto("",""));
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
            comando.SetEmail(new Email(""));
            return comando;
        }
        
    }
}