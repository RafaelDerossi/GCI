using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Tests
{
    public static class VisitaFactory
    {
        public static Visita Factory()
        {
            return new Visita
                (DateTime.Today, "OBS", StatusVisita.PENDENTE, Guid.NewGuid(),
                "Nome do Visitante",TipoDeDocumento.CPF, null, new Cpf("143.026.417-97"),
                 new Email("rafael@condominioapp.com"), new Foto("nomeOriginal.jpg", "foto.jpg"),
                TipoDeVisitante.PARTICULAR, "", Guid.NewGuid(),"Nome Condominio",
                Guid.NewGuid(),"101","1º","Bloco 1", new Veiculo("LMG8888","Modelo","Prata"),
                 Guid.NewGuid(), "Nome usuario");
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
            visita.SetTipoDocumentoVisitante(TipoDeDocumento.RG);
            visita.SetCpfVisitante(null);
            visita.SetRgVisitante(new Rg("123456789"));
            return visita;
        }

        public static Visita CriarVisitaPorteiroValida_SemDocumento()
        {
            var visita = Factory();
            visita.SetTipoDocumentoVisitante(TipoDeDocumento.OUTROS);
            visita.SetCpfVisitante(null);
            visita.SetRgVisitante(null);
            return visita;
        }

    }
}