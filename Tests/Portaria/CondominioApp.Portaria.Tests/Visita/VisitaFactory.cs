using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Tests
{
    public static class VisitaFactory
    {
        public static Visita Factory()
        {
            return new Visita
                (DateTime.Today, "OBS", StatusVisita.PENDENTE, Guid.NewGuid(),
                "Nome do Visitante",TipoDeDocumento.CPF, "143.026.417-97",
                 new Email("rafael@condominioapp.com"), new Foto("nomeOriginal.jpg"),
                TipoDeVisitante.PARTICULAR, "", Guid.NewGuid(), Guid.NewGuid(),
                true, new Veiculo("LMG8888","Modelo","Prata"), Guid.NewGuid());
        }

        public static Visita CriarVisitaPorteiroValida_ComCPF()
        {
            return Factory();            
        }

        public static Visita CriarVisitaMoradorValida()
        {
            var visita = Factory();
            visita.SetDataDeEntrada(DateTime.Today.AddDays(1).Date);
            visita.AprovarVisita();
            return visita;
        }

        public static Visita CriarVisitaPorteiroValida_ComRG()
        {
            var visita = Factory();
            visita.SetDocumentoVisitante("123456789", TipoDeDocumento.RG);            
            return visita;
        }

        public static Visita CriarVisitaPorteiroValida_SemDocumento()
        {
            var visita = Factory();
            visita.SetDocumentoVisitante("", TipoDeDocumento.OUTROS);            
            return visita;
        }

    }
}