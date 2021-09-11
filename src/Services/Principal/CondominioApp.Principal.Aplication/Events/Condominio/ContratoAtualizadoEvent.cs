using System;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoAtualizadoEvent : CondominioEvent
    {      
        public ContratoAtualizadoEvent(Guid contratoId, DateTime dataAssinaturaContrato,
           TipoDePlano tipoPlano, string descricaoContrato, int quantidadeDeUnidadesContratadas)
        {
            ContratoId = contratoId;
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;            
            QuantidadeDeUnidadesContratadas = quantidadeDeUnidadesContratadas;            
        }
    }
}