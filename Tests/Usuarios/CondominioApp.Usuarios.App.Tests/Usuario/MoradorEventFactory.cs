using System;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MoradorEventFactory
    {
        public static MoradorAdicionadoEvent MoradorCadastradoEventFactory()
        {
            return new MoradorAdicionadoEvent
                (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Nome condominio", Guid.NewGuid(), "101", "1", "Bloco A",
                 true, true);
        }

        public static MoradorAdicionadoEvent CriarEventoCadastroDeMorador()
        {
            return MoradorCadastradoEventFactory();
        }        
        
    }
}