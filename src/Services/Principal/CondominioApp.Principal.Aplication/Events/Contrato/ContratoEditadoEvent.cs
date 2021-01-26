using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoEditadoEvent : ContratoEvent
    {      
        public ContratoEditadoEvent(Guid id, Guid condominioId, DateTime dataAssinatura, TipoDePlano tipoPlano, 
           string descricaoContrato, bool ativo, string linkContrato)            
        {
            Id = id;
            CondominioId = condominioId;
            DataAssinatura = dataAssinatura;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;
            Ativo = ativo;
            LinkContrato = linkContrato;
        }

    }
}