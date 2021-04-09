using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Tests
{
    public static class VisitanteFactoryTest
    {
        public static Visitante Factory()
        {
            return new Visitante
                ("Nome Visitante", TipoDeDocumento.CPF, "143.026.417-97",
                 new Email("rafael@condominioapp.com"), new Foto("nomeOriginal.jpg", "foto.jpg"),
                 Guid.NewGuid(), Guid.NewGuid(), false, "",TipoDeVisitante.PARTICULAR,"", true);
        }

        public static Visitante CriarVisitanteValido_ComCPF()
        {
            return Factory();            
        }

        public static Visitante CriarVisitanteValido_ComRG()
        {
            var visitante = Factory();

            visitante.SetDocumento("123456789", TipoDeDocumento.RG);            

            return visitante;
        }

        public static Visitante CriarVisitanteValido_SemDocumento()
        {
            var visitante = Factory();

            visitante.SetDocumento("", TipoDeDocumento.OUTROS);

            return visitante;
        }

        public static Visitante CriarVisitanteInvalido_ComCPFInvalido()
        {
            var visitante = Factory();

            visitante.SetDocumento("143.026.417-98", TipoDeDocumento.CPF);

            return visitante;
        }
    }
}