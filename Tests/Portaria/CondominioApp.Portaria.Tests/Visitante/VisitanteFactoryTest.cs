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
                ("Nome Visitante", TipoDeDocumento.CPF, new Rg(""), new Cpf("143.026.417-97"),
                 new Email("rafael@condominioapp.com"), new Foto("nomeOriginal.jpg", "foto.jpg"),
                 Guid.NewGuid(),"Nome Condominio", Guid.NewGuid(), "101", "1º", "Bloco 1",
                 false, "",TipoDeVisitante.PARTICULAR,"", new Veiculo("LMG8888","Modelo","Prata"));
        }

        public static Visitante CriarVisitanteValido_ComCPF()
        {
            return Factory();            
        }

        public static Visitante CriarVisitanteValido_ComRG()
        {
            var visitante = Factory();

            visitante.SetTipoDeDocumento(TipoDeDocumento.RG);

            visitante.SetRg(new Rg("123456789"));

            visitante.SetCpf(new Cpf(""));

            return visitante;
        }

        public static Visitante CriarVisitanteValido_SemDocumento()
        {
            var visitante = Factory();

            visitante.SetTipoDeDocumento(TipoDeDocumento.OUTROS);

            visitante.SetRg(new Rg(""));

            visitante.SetCpf(new Cpf(""));

            return visitante;
        }

        public static Visitante CriarVisitanteValido_SemVeiculo()
        {
            var visitante = Factory();

            visitante.SetVeiculo(null);          

            return visitante;
        }

    }
}