using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Tests
{
    public static class VisitanteFactory
    {
        public static Visitante Factory()
        {
            return new Visitante
                ("Nome Visitante", TipoDeDocumento.CPF, null, new Cpf("143.026.417-97"),
                 new Email("rafael@condominioapp.com"), new Foto("nomeOriginal.jpg", "foto.jpg"),
                 Guid.NewGuid(),"Nome Condominio", Guid.NewGuid(), "101", "1º", "Bloco 1",
                 false, "",TipoDeVisitante.PARTICULAR,"", new Veiculo("LMG8888","Modelo","Prata"));
        }

        public static Visitante CriarVisitanteValido_ComCPF()
        {
            return Factory();            
        }     

    }
}